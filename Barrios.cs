using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Data;

namespace ALUMNO
{
    class Barrios
    {
        OleDbConnection conector;
        OleDbCommand comando;
        OleDbDataAdapter adaptador;
        DataTable tabla;
        public Barrios()
        {
            conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=Remis.mdb");
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Barrios";

            adaptador = new OleDbDataAdapter(comando);

            tabla = new DataTable();

            adaptador.Fill(tabla);

            DataColumn[] vec = new DataColumn[1];
            vec[0] = tabla.Columns["Barrio"];
            tabla.PrimaryKey = vec;
        }

        public DataTable getdata()
        {
            return tabla;
        }
    }
}
