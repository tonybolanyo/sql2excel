# sql2excel

sql2excel permite realizar consultas a un servidor de bases de datos SQL Server
y actualizar con los resultados un archivo MS Excel. Se puede usar de dos 
formas diferentes: desde la l�nea de comandos o con interfaz gr�fica de Windows
Forms.

# Dependencias

La aplicaci�n necesita de tres dependencias externas que han sido instaladas a
trav�s del gestor de paquetes NuGet (https://www.nuget.org):

* **log4net** v.2.0.5: para generar los logs. M�s informaci�n en 
  https://logging.apache.org/log4net.
* **NDesk.Options** v.0.2.1: para gestionar las opciones en la l�nea de comandos.
  M�s informaci�n en http://www.ndesk.org/Options.
* **Newtonsoft.Json** v.8.0.3: para tratar los archivos JSON. M�s informaci�n en
  http://www.newtonsoft.com/json.

Los iconos utilizados para la interfaz en Windows Forms son del paquete de
iconos **iOS7** de [Icon8](https://icons8.com) bajo la licencia [Creative Commons
Attribution-NoDerivs 3.0 Unported](https://creativecommons.org/licenses/by-nd/3.0/)
que pod�is encontrarlos junto a muchos otros en https://icons8.com.

# Instalaci�n

Para poder usar **sql2excel** primero debes compilar el c�digo, la soluci�n aportada est�
probada con **Visual Studio 10** aunque utilizarlo con cualquier otro compilador
deber�a ser trivial. El primer paso ser� obtener el c�digo fuente clonando el
repositorio mediante **Git**.

```shell
git clone https://github.com/tonybolanyo/sql2excel.git
```

A continuaci�n basta con abrir el archivo de soluci�n ``SQL2Excel.sln`` y
compilar. En ese momento, si tienes instalado el gestor de paquetes NuGet
se descargar�n las dependencias y se compilar� el proyecto.

Por defecto, la soluci�n est� configurada para compilar en modo depuraci�n
y, por tanto, el resultado de la compilaci�n estar� en la ruta ``bin\Debug``.

# C�mo usar sql2excel

Aunque la compilaci�n genera muchos archivos, algunos de ellos son necesarios
solamente si decides modificar y/o depurar la aplicaci�n. Los que son estrictamente
necesarios son el archivo ejecutable, el de configuraci�n de la aplicaci�n y las
librer�as, como ves a continuaci�n:

* log4net.dll
* NDesk.Options.dll
* Newtonsoft.Json.dll
* sql2excel.exe
* sql2excel.exe.config

Puedes copiarlos a una carpeta que est� en el ``path`` para poder usarlo por l�nea
de comandos y crear un acceso directo al ejecutable con el par�metro ``-g`` para 
usarlo en modo gr�fico.

Ya est� listo para ser utilizado

## Configurar una consulta

Lo primero que necesitar�s ser� un archivo de MS Excel que servir� como plantilla
para introducir los datos. Inicialmente el programa est� pensado para no
sobreescribir el archivo original. Necesitar�s anotar las celdas que vas a
modificar mediante la consulta SQL y, por supuesto, la consulta y los datos
de conexi�n al servidor SQL Server.

Con estos datos ya puedes crear tu archivo de configuraci�n de la siguiente
manera:

```json
{
  "Origen":"c:\\temp\\origen.xlsx",
  "Destino":"c:\\temp\\destino.xlsx",
  "Actualizaciones":[
    {
      "Hoja":"hoja1",
      "CeldaInicio":"C4",
      "SQL":"select col1, col2, col3 from tabla1 where col4 = 2016",
      "Trasponer":false
    },{
      "Hoja":"hoja2",
      "CeldaInicio":"D1",
      "SQL":"select col2, col8 from tabla1 where col4 = 2016",
      "Trasponer":true
    },{
      "Hoja":"hoja3",
      "CeldaInicio":"C7",
      "SQL":"select col1, col5, col7 from tabla1 where col2 = 12",
      "Trasponer":true
    }
  ]
}
```

Supongamos que el archivo se guarda como ``c:\temp\actualizacion.json``,
para realizar la actualizaci�n desde la l�nea de comandos bastar� con
ejecutar la siguiente instrucci�n:

```shell
sql2excel -c c:\temp\actualizacion.json -s servidor -d basedatos
```

donde ``servidor`` corresponde con el nombre o la direcci�n IP del 
servidor SQL Server y ``basedatos`` corresponde al nombre de la 
base de datos que contine las tablas a consultar.

Una vez acabado el proceso tendremos el archivo ``destino.xlsx``
con los datos actualizados.

# Licencia

El programa se distribuye bajo la licencia GNU GENERAL PUBLIC LICENSE
Version 3, que puede leerse en el archivo LICENSE.

# Autor

Tony G. Bola�o
http://tonygb.com