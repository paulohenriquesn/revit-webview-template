@echo off
@RD /S /Q release
@RD /S /Q bin
@RD /S /Q obj
dotnet publish -c Release -o release/Addin/
copy Addin.addin release