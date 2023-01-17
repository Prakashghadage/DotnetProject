namespace BLL;
using System.Collections.Generic;
using System.Text.Json;
using BOL;
using DAL;
public class Middle
{

public List<Players> getAllList(){

    List<Players> playerlist=new List<Players>();
               playerlist =DBManager.getAllPlayers();
    return playerlist;
}


public Players GetPlayersdb(int id){

    Players playerlist=new Players();
               playerlist =DBManager.GetPlayer(id);
    return playerlist;
}

public bool Insertdata(Players player)
{
   
   Players obj=new Players();
    bool sta=DBManager.Insert(player);
    return sta;
}

public bool Updatedata(Players player)
{
   
   Players obj=new Players();
    bool sta=DBManager.Update(player);
    return sta;
}

public bool Deletedata(int id){

    Players playerlist=new Players();
    bool status=DBManager.Delete(id);
      return status;
}

public bool RegisterUser(int id,string name,string city){
    bool status=false;
Console.WriteLine("IN serelization");
Customer c=new Customer();
List<Customer> updatelist=CustomerAuth.addData(c);
var option =new JsonSerializerOptions{IncludeFields=true};
var Customerjson=JsonSerializer.Serialize<List<Customer>>(updatelist,option);
string filename=@"E:\customers.json";
Console.WriteLine("data added successfully");
System.IO.File.WriteAllText(filename,Customerjson);
status=true;
return status;

}

}
