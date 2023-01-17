namespace BLL;
using BOL;

public class CustomerAuth{

public static List<Customer> list=new List<Customer>();
public static List<Customer> addData(Customer c){
    list.Add(c);
    return list;


}
}