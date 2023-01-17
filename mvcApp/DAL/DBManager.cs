namespace DAL;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BOL;
public class DBManager
{

    
  public static string conString=@"server=localhost;port=3306;user=root; password=root123;database=players";       


  public static List<Players> getAllPlayers()
  {
    Players player=null;
       List<Players> allplayer=new List<Players>();
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
      
        try{
            string query="SELECT * FROM playerinfo";
                   con.Open();
                 MySqlCommand cmd=new MySqlCommand(query,con);
                 MySqlDataReader reader=cmd.ExecuteReader();
                 while(reader.Read()){
                    int id=int.Parse(reader["id"].ToString());
                    string name=reader["name"].ToString();
                    string city=reader["city"].ToString();
                          
                          player=new Players{
                              Id=id,
                              Name=name,
                              City=city

                          };

                      allplayer.Add(player);
                 }


        }
        catch(Exception e){
                  Console.WriteLine(e.Message);
        }
        finally {
            con.Close();
        }




       return allplayer;

  }


  public static Players GetPlayer(int Id)
  {
    Players player=null;
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
      
        try{
            string query="SELECT * FROM playerinfo WHERE id="+Id;
                   con.Open();
                 MySqlCommand cmd=new MySqlCommand(query,con);
                 MySqlDataReader reader=cmd.ExecuteReader();
                 if(reader.Read()){
                    int id=int.Parse(reader["id"].ToString());
                    string name=reader["name"].ToString();
                    string city=reader["city"].ToString();
                          
                          player=new Players{
                              Id=id,
                              Name=name,
                              City=city

                          };
                 }
        }
        catch(Exception e){
                  Console.WriteLine(e.Message);
        }
        finally {
            con.Close();
        }
       return player;

  }

   public static bool Insert(Players player)
  {
    bool status=false;
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
      
        try{
            string query="INSERT INTO playerinfo values ('"+player.Id +"','"+player.Name+"','"+player.City+"')";
               con.Open();
                 MySqlCommand cmd=new MySqlCommand(query,con);
                 
                 cmd.ExecuteNonQuery();
                status=true;               
        }
        catch(Exception e){
                  Console.WriteLine(e.Message);
        }
        finally {
            con.Close();
        }
       return status;

  }

   public static bool Update(Players player)
  {
    bool status=false;
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
      
        try{
             string query = "UPDATE playerinfo SET name='" + player.Name + "', city='" +player.City + "' WHERE id=" +player.Id;
               con.Open();
                 MySqlCommand cmd=new MySqlCommand(query,con);
                 
                 cmd.ExecuteNonQuery();
                status=true;               
        }
        catch(Exception e){
                  Console.WriteLine(e.Message);
        }
        finally {
            con.Close();
        }
       return status;

  }

   public static bool Delete(int id)
  {
    bool status=false;
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
      
        try{
             string query = "DELETE FROM playerinfo WHERE id=" + id ;
               con.Open();
                 MySqlCommand cmd=new MySqlCommand(query,con);
                 
                 cmd.ExecuteNonQuery();
                status=true;               
        }
        catch(Exception e){
                  Console.WriteLine(e.Message);
        }
        finally {
            con.Close();
        }
       return status;

  }
}
