@echo off
setlocal
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

mode con cols=160 lines=60
echo.
echo La ventana de la consola está en pantalla completa. Presiona una tecla para restaurar el tamaño original.
pause > nul
mode con cols=80 lines=25

endlocal
