@echo off
setlocal

set REPO_DIR=C:\Users\alumMA\JuegoCasa
set COMMIT_MESSAGE="Mensaje del commit automático"

cd /d "%REPO_DIR%"

echo Realizando commit...
git add .
git commit -m %COMMIT_MESSAGE%

echo Realizando push...
git push

echo Proceso completado.

endlocal
