param(
    [string]$TargetPath = "../ShareNotBuild"
)

function Get-FileEncoding {
    param(
        [string] $FilePath
    )

    $fs = [System.IO.FileStream]::new($FilePath, [System.IO.FileMode]::Open, [System.IO.FileAccess]::Read)
    try {
        [byte[]] $bom = New-Object byte[] 4
        $count = $fs.Read($bom, 0, 4)

        if ($count -ge 3 -and $bom[0] -eq 0xEF -and $bom[1] -eq 0xBB -and $bom[2] -eq 0xBF) {
            return [Text.Encoding]::UTF8
        }
        elseif ($count -ge 2 -and $bom[0] -eq 0xFF -and $bom[1] -eq 0xFE) {
            return [Text.Encoding]::Unicode
        }
        elseif ($count -ge 2 -and $bom[0] -eq 0xFE -and $bom[1] -eq 0xFF) {
            return [Text.Encoding]::BigEndianUnicode
        }
        else {
            return $null
        }
    }
    finally {
        $fs.Close()
    }
}

function Rename-Files {
    git ls-files | Split-Path -Parent | sort | unique | Get-ChildItem -Directory |
    Where-Object {
            ($_.Name -like "*ShareX*")
    } |
    Sort-Object -Property FullName -Descending |
    ForEach-Object {
        $oldName = $_.FullName
        $newName = $oldName -replace "ShareX", "ShareNot"

        Write-Host "Renaming directory:" $_.Name "→" ([System.IO.Path]::GetFileName($newName))
        git mv -f -- $oldName $newName
    }

    git ls-files | Get-ChildItem |
    Where-Object {
            ($_.Name -like "*ShareX*")
    } |
    Sort-Object -Property FullName -Descending |
    ForEach-Object {
        $oldName = $_.FullName
        $newName = $oldName -replace "ShareX", "ShareNot"

        Write-Host "Renaming file:" $_.Name "->" ([System.IO.Path]::GetFileName($newName))
        git mv -f -- $oldName $newName
    }
}

function Update-Files {
    # List non binary files by checking if there is a character present
    $files = git grep -I --name-only --untracked -e . | Get-ChildItem

    $pattern = "(?<!https?\S*)ShareX(?!\s+Team)"

    foreach ($file in $files) {
        Write-Host "Checking file:" $file.FullName

        Write-Host " -> Processing..."

        $enc = Get-FileEncoding $file.FullName
        if (-not $enc) {
            $enc = [Text.Encoding]::UTF8
            Write-Host "No BOM found, defaulting to UTF-8"
        }
        else {
            Write-Host "Detected encoding:" $enc.WebName
        }

        $content = [System.IO.File]::ReadAllText($file.FullName, $enc)
        $newContent = $content -replace $pattern, "ShareNot"

        if ($newContent -ne $content) {
            Write-Host "Found occurrences"
            [System.IO.File]::WriteAllText($file.FullName, $newContent, $enc)
        }
        else {
            Write-Host "No occurrences"
        }
    }
}

if (Test-Path -Path $TargetPath) {
    Write-Host "Removing existing $TargetPath ..."
    Remove-Item -LiteralPath $TargetPath -Recurse -Force
}

Write-Host "Cloning current repository into $TargetPath ..."
git clone . $TargetPath

Set-Location $TargetPath

Rename-Files

Update-Files

Write-Host "All done"
