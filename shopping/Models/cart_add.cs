namespace shopping.Models
{
    public class cart_add
    {
        public static List<Cart> DATA = new List<Cart>();   
        public  void ADD(Cart c) { DATA.Add(c); }
        public void REMOVE(Cart c) { DATA.Remove(c); }

        public Cart FIND(int id)
        {
            var temp = DATA.Where(x=>x.Productid==id).FirstOrDefault();
            return temp;
        }

        public List<Cart> temp()
        {
            return DATA;
        }
        public void REMOVEALL()
        {
            DATA.Clear();
        }
             
    }
}
