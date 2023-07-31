public DataTable ListarUsuario(){
    Conexion.Open();
    DataTable dt = new DataTable;
    string sql = "SELECT * FROM Usuario";
    SqlCommand cmd = SqlCommand(sql, Conexion.Conectar());
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(dt);
    return dt;
}

public DataTable ListarPerfiles(){
    Conexion.Conectar();
    DataTable dt = new DataTable;
    string sql = "SELECT * FROM Perfil";
    SqlCommand cmd = SqlCommand(sql, Conexion.Conectar());
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(dt);
    return dt;
}

public DataTable ListarPerfilesXUsuario(){
    Conexion.Open();
    DataTable dt = new DataTable;
    string sql = "Select u.codigoUsuario,u.nombre,u.apellido, p.nombrePerfil from Usuario u" +
                 "Inner join UsuarioPerfil up u.codigoUsuario = up.codigoUsuario" +
                 "Inner join Perfil p up.codigoPerfil = u.codigoPerfil" +
                 "group by u.codigoUsuario" +
                 "order by u.codigoUsuario desc";
    SqlCommand cmd = SqlCommand(sql, Conexion.Conectar());
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(dt);
    return dt;
}

public Boolean Insertar(string nombre, string apellido, string genero, string email, int estado)
{
  Boolean inserto = true;
  Conexion.Open();
  string sql = "SP_INSERTAR";
  SqlCommand cmd = SqlCommand(sql, Conexion.Conectar());
  cmd.CommandType = CommandType.StoreProcedure;
  cmd.Parameters.AddWithValue("nombre", nombre);
  cmd.Parameters.AddWithValue("apellido", apellido);
  cmd.Parameters.AddWithValue("genero", genero);
  cmd.Parameters.AddWithValue("email", email);
  cmd.Parameters.AddWithValue("estado", estado);

  try
  {
    cmd.ExecuteNonQuery();
  }
  catch (Exception ex)
  {
    MessageBox.Show(ex.toString());
    Boolean inserto = false;
  }
   Conexion.close();
   return inserto;
}