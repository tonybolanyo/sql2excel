# sql2excel

sql2excel permite realizar consultas a un servidor de bases de datos SQL Server
y actualizar con los resultados un archivo MS Excel. Se puede usar de dos 
formas diferentes: desde la línea de comandos o con interfaz gráfica de Windows
Forms.

# Dependencias

La aplicación necesita de tres dependencias externas que han sido instaladas a
través del gestor de paquetes NuGet (https://www.nuget.org):

* **log4net** v.2.0.5: para generar los logs. Más información en 
  https://logging.apache.org/log4net.
* **NDesk.Options** v.0.2.1: para gestionar las opciones en la línea de comandos.
  Más información en http://www.ndesk.org/Options.
* **Newtonsoft.Json** v.8.0.3: para tratar los archivos JSON. Más información en
  http://www.newtonsoft.com/json.

Los iconos utilizados para la interfaz en Windows Forms son del paquete de
iconos **iOS7** de [Icon8](https://icons8.com) bajo la licencia [Creative Commons
Attribution-NoDerivs 3.0 Unported](https://creativecommons.org/licenses/by-nd/3.0/)
que podéis encontrarlos junto a muchos otros en https://icons8.com.

# Instalación

Para poder usar **sql2excel** primero debes compilar el código, la solución aportada está
probada con **Visual Studio 10** aunque utilizarlo con cualquier otro compilador
debería ser trivial. El primer paso será obtener el código fuente clonando el
repositorio mediante **Git**.

```shell
git clone https://github.com/tonybolanyo/sql2excel.git
```

A continuación basta con abrir el archivo de solución ``SQL2Excel.sln`` y
compilar. En ese momento, si tienes instalado el gestor de paquetes NuGet
se descargarán las dependencias y se compilará el proyecto.

Por defecto, la solución está configurada para compilar en modo depuración
y, por tanto, el resultado de la compilación estará en la ruta ``bin\Debug``.

# Cómo usar sql2excel

Aunque la compilación genera muchos archivos, algunos de ellos son necesarios
solamente si decides modificar y/o depurar la aplicación. Los que son estrictamente
necesarios son el archivo ejecutable, el de configuración de la aplicación y las
librerías, como ves a continuación:

* log4net.dll
* NDesk.Options.dll
* Newtonsoft.Json.dll
* sql2excel.exe
* sql2excel.exe.config

Puedes copiarlos a una carpeta que esté en el ``path`` para poder usarlo por línea
de comandos y crear un acceso directo al ejecutable con el parámetro ``-g`` para 
usarlo en modo gráfico.

Ya está listo para ser utilizado

## Configurar una consulta

Lo primero que necesitarás será un archivo de MS Excel que servirá como plantilla
para introducir los datos. Inicialmente el programa está pensado para no
sobreescribir el archivo original. Necesitarás anotar las celdas que vas a
modificar mediante la consulta SQL y, por supuesto, la consulta y los datos
de conexión al servidor SQL Server.

Con estos datos ya puedes crear tu archivo de configuración de la siguiente
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
para realizar la actualización desde la línea de comandos bastará con
ejecutar la siguiente instrucción:

```shell
sql2excel -c c:\temp\actualizacion.json -s servidor -d basedatos
```

donde ``servidor`` corresponde con el nombre o la dirección IP del 
servidor SQL Server y ``basedatos`` corresponde al nombre de la 
base de datos que contine las tablas a consultar.

Una vez acabado el proceso tendremos el archivo ``destino.xlsx``
con los datos actualizados.

# Licencia

El programa se distribuye bajo la licencia GNU GENERAL PUBLIC LICENSE
Version 3, que puede leerse en el archivo LICENSE.

# Autor

Tony G. Bolaño
http://tonygb.com