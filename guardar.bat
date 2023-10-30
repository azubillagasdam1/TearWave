@echo off
setlocal
mode con cols=160 lines=60
color 0a

set "SCRIPT_DIR=%~dp0"
set "REPO_DIR=%SCRIPT_DIR%"
set "COMMIT_MESSAGE=Mensaje del commit automático"

cd /d "%REPO_DIR%"

echo Realizando commit...
git add .
git commit -m "%COMMIT_MESSAGE%"

echo Realizando push...
git push

echo Proceso completado.
echo "Presiona una tecla para continuar..."
pause

endlocal