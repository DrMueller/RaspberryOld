@ECHO OFF

set DOTNETFX4=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX4%

echo Uninstalling LyncConnectorService...
echo ---------------------------------------------------
InstallUtil /u ../LyncconnectorService.exe
echo ---------------------------------------------------
echo Done.