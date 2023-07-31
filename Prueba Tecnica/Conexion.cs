public class Conexion
{
    public static sqlConnection Conectar(){
        sqlConnection cn = sqlConnection("SERVER=Prueba;DATABASE=Prueba;integrated security=true;");
        cn.Open();
        return cn;
    }
}