namespace TestNinja.Fundamentals
{
    public class CustomerController
    {
        public ActionResult GetCustomer(int id)
        {
            if (id < 0) throw new ArgumentException("Id cannot less than 0");
            if (id == 0)
                return new NotFound();
            
            return new Ok();
        }        
    }
    
    public class ActionResult { }
    
    public class NotFound : ActionResult { }
 
    public class Ok : ActionResult { }
}