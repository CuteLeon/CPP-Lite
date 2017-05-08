@cd /d "%~dp0"

@move *.obj ..\Bulid\

@link ../Bulid/*.obj /out:Temp.dll /nologo /dll /incremental:no > ../Bulid/ret.txt

@move Temp.* ..\Bulid\