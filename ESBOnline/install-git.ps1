# Download Git installer
Invoke-WebRequest -Uri 'https://github.com/git-for-windows/git/releases/download/v2.31.1.windows.1/Git-2.31.1-64-bit.exe' -OutFile 'C:\Git-2.31.1-64-bit.exe'

# Install Git silently with default options
Start-Process -FilePath 'C:\Git-2.31.1-64-bit.exe' -ArgumentList '/SILENT' -Wait

# Add Git to PATH environment variable
[Environment]::SetEnvironmentVariable('Path', "$env:Path;C:\Program Files\Git\bin", [EnvironmentVariableTarget]::Machine)
