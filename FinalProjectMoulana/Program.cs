using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectMoulana
{
    class Program
    {
        static void Main(string[] args)
        {
            int command;
            bool definer = true;

            while (definer == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("{0,90}", "WELCOME TO \"MOULANA SHOPPING SYSTEM\"\n");
                    Console.WriteLine("PLEASE ENTER A NUMBER TO EXECUTE THE CORRESPONDING COMMAND:\n");
                    Console.Write("{0,0}", "\n 1:  ADD A PRODUCT");
                    Console.WriteLine("{0,35}", " 2:  REMOVE A PRODUCT");
                    Console.Write("{0,0}", "\n 3:  ADD A CUSTOMER");
                    Console.WriteLine("{0,35}", " 4:  REMOVE A CUSTOMER");
                    Console.Write("{0,0}", "\n 5:  ADD A DEALER");
                    Console.WriteLine("{0,35}", " 6:  REMOVE A DEALER");
                    Console.WriteLine("\n 7:  BUY A PRODUCT BY A CUSTOMER");
                    Console.WriteLine("\n 8:  CALCULATE AND DISPLAY THE TOTAL PURCHASES OF A CUSTOMER");
                    Console.WriteLine("\n 9:  GET CUSTOMER LIST OF A SPECIFIC PRODUCT");
                    Console.WriteLine("\n 10: GET CUSTOMER LIST OF A SPECIFIC DEALER");
                    Console.WriteLine("\n 11: GET NUMBER OF SALES OF A SPECIFIC PRODUCT");
                    Console.WriteLine("\n 12: GET LIST OF PRODUCTS PURCHASED BY A CUSTOMER");
                    Console.WriteLine("\n 13: GET LIST OF DEALERS AND THEIR TOTAL SALES");
                    Console.WriteLine("\n 14: SHOW PRODUCTS");
                    Console.WriteLine("\n 15: SHOW CUSTOMERS");
                    Console.WriteLine("\n 16: SHOW DEALERS");
                    Console.WriteLine("\n 17: EXIT");
                    command = Convert.ToInt32(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            Console.Clear();
                            Product.AddProduct();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            Product.RemoveProduct();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            Customer.AddCustomer();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            Customer.RemoveCustomer();
                            Console.Clear();
                            break;
                        case 5:
                            Console.Clear();
                            Dealer.AddDealer();
                            Console.Clear();
                            break;
                        case 6:
                            Console.Clear();
                            Dealer.RemoveDealer();
                            Console.Clear();
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Enter the customer code:");
                            int customerID = Convert.ToInt32(Console.ReadLine());
                            ShoppingSystem.BuyByCostumer(customerID);
                            Console.Clear();
                            break;
                        case 8:
                            Console.Clear();
                            Console.WriteLine("Enter the customer code:");
                            int CustomerID = Convert.ToInt32(Console.ReadLine());
                            ShoppingSystem.ShowCustomerPurchases(CustomerID);
                            Console.Clear();
                            break;
                        case 9:
                            Console.Clear();
                            Console.WriteLine("To get the list of customers of a specific product, enter the product's code:");
                            int productCode = Convert.ToInt32(Console.ReadLine());
                            var customersList = ShoppingSystem.CustomersListOfSpecificProduct(productCode);
                            foreach (var item in customersList)
                            {
                                Console.WriteLine(item);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 10:
                            Console.Clear();
                            Console.WriteLine("To get the list of products of a specific dealer, enter the dealer's Economic code:");
                            int economicCode = Convert.ToInt32(Console.ReadLine());
                            var productsList = ShoppingSystem.ProductsListOfSpecificDealer(economicCode);
                            foreach (var item in productsList)
                            {
                                Console.WriteLine(item);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 11:
                            Console.Clear();
                            Console.WriteLine("Enter the Product ID:");
                            int productCode1 = Convert.ToInt32(Console.ReadLine());
                            ShoppingSystem.ProductSales(productCode1);
                            Console.Clear();
                            break;
                        case 12:
                            Console.Clear();
                            Console.WriteLine("To get the list of products of a specific customer, enter the customer's code:");
                            int customerCode = Convert.ToInt32(Console.ReadLine());
                            var productsList1 = ShoppingSystem.ProductsListOfSpecificCustomer(customerCode);
                            foreach (var item in productsList1)
                            {
                                Console.WriteLine(item);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 13:
                            Console.Clear();
                            ShoppingSystem.DealersSales();
                            Console.Clear();
                            break;
                        case 14:
                            Console.Clear();
                            Product.ShowProducts();
                            Console.Clear();
                            break;
                        case 15:
                            Console.Clear();
                            Customer.ShowCustomers();
                            Console.Clear();
                            break;
                        case 16:
                            Console.Clear();
                            Dealer.ShowDealers();
                            Console.Clear();
                            break;
                        case 17:
                            definer = false;
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }
                catch (Exception Error)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Clear();
                    Console.WriteLine(Error.Message);
                    Console.ReadKey();
                }
            }
        }
    }
    
    class Customer
    {
        private string firstName { get; set; }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        private string lastName { get; set; }
        public string LastName { get { return lastName; } set { lastName = value; } }
        private string gender { get; set; }
        public string Gender
        {
            get { return gender; }
            set
            {
                if (value.Equals("male", StringComparison.OrdinalIgnoreCase) || value.Equals("female", StringComparison.OrdinalIgnoreCase))
                    gender = value;
                else
                    throw new Exception("The gender is written incorrect !");
            }
        }
        private int code;
        public int Code
        {
            get { return code; }
            set
            {
                foreach (var item in ShoppingSystem.customers)
                {
                    if (item.code == value)
                        throw new Exception("The customer with this code already exists");
                }
                if (value >= 0)
                    code = value;
                else
                    throw new Exception("Customer code must be {0,1,2,...}");
            }
        }
        private int id { get; set; }
        public int ID
        {
            get { return code; }
            set
            {
                foreach (var item in ShoppingSystem.customers)
                {
                    if (item.id == value)
                        throw new Exception("The customer with this ID already exists");
                }
                if (value >= 0)
                    id = value;
                else
                    throw new Exception("Customer ID must be {0,1,2,...}");
            }
        }
        private DateTime birthDate { get; set; }
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; } }
        private string state { get; set; }
        public string State { get { return state; } set { state = value; } }
        private string city { get; set; }
        public string City { get { return city; } set { city = value; } }
        
        public Customer(string firstName, string lastName, string gender, int code,
            int id, DateTime birthDate, string state, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Code = code; 
            ID = id;
            BirthDate = birthDate;
            State = state;
            City = city;
        }
        public static void AddCustomer()
        {
            Console.WriteLine("- ADDING A CUSTOMER -\n\nPlease enter the first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter the last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Please enter the gender: (male/female)");
            string gender = Console.ReadLine();
            Console.WriteLine("Please enter the code:");
            int code = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the date of the birth: (YYYY/MM/DD)");
            DateTime birthDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter the state:");
            string state = Console.ReadLine();
            Console.WriteLine("Please enter the city:");
            string city = Console.ReadLine();
            Customer c = new Customer(firstName, lastName, gender, code, id, birthDate, state, city);
            ShoppingSystem.customers.Add(c);
            Console.WriteLine("The customer has been added successfully !");
            Console.ReadKey();
        }
        public static void RemoveCustomer()
        {
            Console.WriteLine("- REMOVING A CUSTOMER -\n\nBy which of the following methods do you want to remove the customer?" +
                "\n\nCustomer's code: enter 0" +
                "\nCustomer's ID: enter 1");
            
            int command = Convert.ToInt32(Console.ReadLine());
            bool definer = false;
            switch (command)
            {
                case 0:
                    Console.WriteLine("Enter the code:");
                    int code = Convert.ToInt32(Console.ReadLine());

                    foreach (var item in ShoppingSystem.customers.ToList())
                    {
                        if (item.code == code )
                        {
                            definer = true;
                            ShoppingSystem.customers.Remove(item);
                            Console.WriteLine("the customer has been removed successfully !");
                            Console.ReadKey();
                        }
                    }
                    if (definer == false)
                    {
                        throw new Exception("There is not any customer with this code !");
                    }

                    foreach (var item in ShoppingSystem.customerProducts.ToList())
                    {
                        if (item.Person.code == code)
                            ShoppingSystem.customerProducts.Remove(item);
                    }
                    break;
                case 1:
                    Console.WriteLine("Enter the ID:");
                    int ID = Convert.ToInt32(Console.ReadLine());

                    foreach (var item in ShoppingSystem.customers.ToList())
                    {
                        if (item.ID == ID)
                        {
                            definer = true;
                            ShoppingSystem.customers.Remove(item);
                            Console.WriteLine("the customer ({0} {1}) has been removed successfully !", item.FirstName, item.LastName);
                            Console.ReadKey();
                        }
                    }
                    if (definer == false)
                    {
                        throw new Exception("There is not any customer with this ID !");
                    }

                    foreach (var item in ShoppingSystem.customerProducts.ToList())
                    {
                        if (item.Person.ID == ID)
                            ShoppingSystem.customerProducts.Remove(item);
                    }
                    break;
            }
        }
        public static Customer ReturnCustomer(int code)
        {
            foreach (var item in ShoppingSystem.customers)
            {
                if (item.code == code)
                    return item;
            }
            return null;
        }

        public static void ShowCustomers()
        {
            if (ShoppingSystem.customers.Count() == 0)
                throw new Exception("Not any customers were entered before !");

            foreach (var item in ShoppingSystem.customers)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public override string ToString()
        {
            return string.Format("Full Name: {0} {1}, Code: {2}, ID: {3}, Gender: {4}, Location: {5}, {6}, Birthday Date: {7}",
                FirstName, LastName, Code, ID, Gender, State, City, BirthDate);
        }
    }
    class Dealer
    {
        private string dealerName { get; set; }
        public string DealerName { get { return dealerName; } set { dealerName = value; } }
        private DateTime establishYear { get; set; }
        public DateTime EstablishYear { get { return establishYear; } set { establishYear = value; } }
        private int economicCode;
        public int EconomicCode
        {
            get { return economicCode; }
            set
            {
                foreach (var item in ShoppingSystem.dealers)
                {
                    if (item.EconomicCode == value)
                        throw new Exception("Thhe economoic code is already registered");
                }

                if (value >= 0)
                    economicCode = value;
                else
                    throw new Exception("the economic code must be {0,1,2,...}");
            }
        }
        private string ownerFirstName { get; set; }
        public string OwnerFirstName { get { return ownerFirstName; } set { ownerFirstName = value; } }
        private string ownerLastName { get; set; }
        public string OwnerLastName { get { return ownerLastName; } set {ownerLastName = value; } }
        private string state { get; set; }
        public string State { get { return state; } set { state = value; } }
        private string city { get; set; }
        public string City { get { return city; } set { city = value; } }

        public Dealer(string dealerName, DateTime foundYear, int economicCode, string ownerFirstName,
            string ownerLastName, string state, string city)
        {
            DealerName = dealerName;
            EstablishYear = establishYear;
            EconomicCode = economicCode;
            OwnerFirstName = ownerFirstName;
            OwnerLastName = ownerLastName;
            State = state;
            City = city;
        }
        public static void AddDealer()
        {
            Console.WriteLine("- ADDING A DEALER -\n\nPlease enter the dealer name:");
            string dealerName = Console.ReadLine();
            Console.WriteLine("Please enter the year of foundation:");
            DateTime establishYear = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter the economic code:");
            int economicCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the owner's first name:");
            string ownerFirstName = Console.ReadLine();
            Console.WriteLine("Please enter the owner's last name:");
            string ownerLastName = Console.ReadLine();
            Console.WriteLine("Please enter the state:");
            string state = Console.ReadLine();
            Console.WriteLine("Please enter the city:");
            string city = Console.ReadLine();

            Dealer p = new Dealer(dealerName, establishYear, economicCode, ownerFirstName, ownerLastName, state, city);
            ShoppingSystem.dealers.Add(p);
            Console.WriteLine("The dealer has been added successfully !");
            Console.ReadKey();

        }
        public static void RemoveDealer()
        {
            Console.WriteLine("- REMOVING A DEALER -\n\nPlease enter the dealer's economic code:");
            int code = Convert.ToInt32(Console.ReadLine());
            bool definer = false;
            foreach (var item in ShoppingSystem.dealers.ToList())
            {
                if (item.EconomicCode == code)
                {
                    definer = true;
                    ShoppingSystem.dealers.Remove(item);
                    Console.WriteLine("the dealer ({0}) has been removed successfully !", item.DealerName);
                    Console.ReadKey();
                }
            }
            if (definer == false)
            {
                throw new Exception("There is not any dealer with this economic code !");
            }

            foreach (var item in ShoppingSystem.customerProducts.ToList())
            {
                if (item.ShopName.EconomicCode == code)
                    ShoppingSystem.customerProducts.Remove(item);
            }
        }
        public static Dealer ReturnDealer(int code)
        {
            foreach (var item in ShoppingSystem.dealers)
            {
                if (item.economicCode == code)
                    return item;
            }
            return null;
        }

        public static void ShowDealers()
        {
            if (ShoppingSystem.dealers.Count() == 0)
                throw new Exception("Not any dealers were entered before !");

            foreach (var item in ShoppingSystem.dealers)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public override string ToString()
        {
            return string.Format("Dealer Name: {0}, Economic Code: {1}, Establish Year: {2}\nOwner Full Name: {3} {4}, Location: {5}, {6}",
                DealerName, economicCode, establishYear, ownerFirstName, ownerLastName, State, City);
        }
    }
    class Product
    {
        private string name { get; set; }
        public string Name { get { return name; } set { name = value; } }
        private int code { get; set; }
        public int Code
        {
            get { return code; }
            set
            {
                foreach (var item in ShoppingSystem.products)
                {
                    if (item.code == value)
                        throw new Exception("The economoic code is already registered");
                }

                if (value >= 0)
                    code = value;
                else
                    throw new Exception("the economic code must be {0,1,2,...}");
            }
        }
        private string brand { get; set; }
        public string Brand { get { return brand; } set { brand = value; } }
        private int price { get; set; }
        public int Price {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
                else
                    throw new Exception("Prices must be greater than zero !");
            }
        }
        private double weight { get; set; }
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                    weight = value;
                else
                    throw new Exception("the weight must be greater than zero !");
            }
        }
        public Product(string name, int code, string brand, int price, double weight)
        {
            Name = name;
            Code = code;
            Brand = brand;
            Price = price;
            Weight = weight;
        }
        public static void AddProduct()
        {
            Console.WriteLine("- Adding a product -\nPlease enter the name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the code:");
            int code = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the brand:");
            string brand = Console.ReadLine();
            Console.WriteLine("Please enter the price:");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the weight: (in  gram)");
            double weight = Convert.ToDouble(Console.ReadLine());

            Product p = new Product(name, code, brand, price, weight);
            ShoppingSystem.products.Add(p);
            Console.WriteLine("The product has been added successfully !");
            Console.ReadKey();
        }
        public static void RemoveProduct()
        {
            Console.WriteLine("- Removing a product -\nPlease enter the product's code:");
            int code = Convert.ToInt32(Console.ReadLine());
            bool definer = false;
            foreach (var item in ShoppingSystem.products.ToList())
            {
                if (item.Code == code)
                {
                    definer = true;
                    ShoppingSystem.products.Remove(item);
                    Console.WriteLine("the product ({0}) has been removed successfully !", item.Name);
                }
            }
            if (definer == false)
                throw new Exception("There is not any product with this code !");

            foreach (var item in ShoppingSystem.customerProducts.ToList())
            {
                if (item.Product.Code == code)
                    ShoppingSystem.customerProducts.Remove(item);
            }
            Console.ReadKey();
        }
        public static Product ReturnProduct(int code)
        {
            foreach (var item in ShoppingSystem.products)
            {
                if (item.Code == code)
                    return item;
            }
            return null;
        }
        public static void ShowProducts()
        {
            if (ShoppingSystem.products.Count() == 0)
                throw new Exception("Not any products were entered before !");

            foreach (var item in ShoppingSystem.products)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        public override string ToString()
        {
            return string.Format("Product: {0} {1}, Code: {2}, price: {3}$, weight: {2:F1}gram", Brand, Name, Code, Price, Weight);
        }
    }
    class CustomerProduct
    {
        private Dealer shopName { get; set; }
        public Dealer ShopName { get { return shopName; } set { shopName = value; } }
        private Customer person { get; set; }
        public Customer Person { get { return person; } set { person = value; } }
       
        private Product product { get; set; }
        public Product Product { get { return product; } set { product = value; } }
        private int quantity { get; set; }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value >= 0)
                    quantity = value;
                else
                    throw new Exception("The product quantity must be (0,1,2,...)");
            }
        }
        private DateTime purchaseDate { get; set; }
        public DateTime PurchaseDate { get { return purchaseDate; } set { purchaseDate = value; } }
        public CustomerProduct(Dealer shopName, Customer person, Product product, int quantity, DateTime purchaseDate)
        {
            ShopName = shopName;
            Person = person;
            Product = product;
            Quantity = quantity;
            PurchaseDate = purchaseDate;
        }

    }
    class ShoppingSystem
    {
        public static List<Customer> customers = new List<Customer>();
        public static List<Dealer> dealers = new List<Dealer>();
        public static List<Product> products = new List<Product>();
        public static List<CustomerProduct> customerProducts = new List<CustomerProduct>();

        public static void BuyByCostumer(int code)
        {
            Customer person = Customer.ReturnCustomer(code);

            if (person is null)
                throw new Exception("There is not any customer with this code !");

            Console.WriteLine("Enter the economic code of the shop you want to buy from:");
            int economicCode = Convert.ToInt32(Console.ReadLine());
            Dealer shop = Dealer.ReturnDealer(economicCode);

            if (shop is null)
                throw new Exception("There is not any shop with this code !");

            Console.WriteLine("Enter the code of the the product you want to buy:");
            int productCode = Convert.ToInt32(Console.ReadLine());
            Product product = Product.ReturnProduct(productCode);

            if (product is null)
                throw new Exception("There is not any product with this code !");

            Console.WriteLine("How many of this product do you want to buy?: (1,2,...)");
            int quantity = Convert.ToInt32(Console.ReadLine());

            if (quantity == 0)
                throw new Exception("you buyed nothing !");

            DateTime purchaseDate = DateTime.Now;
            CustomerProduct Order = new CustomerProduct(shop, person, product, quantity, purchaseDate);
            customerProducts.Add(Order);
            Console.WriteLine("{0} {1} has been bought by {2} {3} successfully !", product.Brand, product.Name, person.FirstName, person.LastName);
            Console.ReadKey();
        }
        public static void ShowCustomerPurchases(int code)
        {
            Customer person = Customer.ReturnCustomer(code);

            if (person is null)
                throw new Exception("There is no customer with this code !");

            bool definer = false;

            foreach (var item in customerProducts)
            {
                if (item.Person == person)
                    definer = true;
            }

            if (definer == false)
                throw new Exception("This customer didn't buy anything before !");

            Console.WriteLine(person);
            foreach (var item in customerProducts)
            {
                if (item.Person.Code == code)
                {
                    Console.WriteLine();
                    Console.WriteLine(item.Product);
                }
            }
        }
        public static List<Customer> CustomersListOfSpecificProduct(int code)
        {
            var customerList =
                from item in customerProducts
                where item.Product.Code == code
                select item.Person;

            if (customerList is null)
                throw new Exception("there's not any customer that bought this product !");

            return customerList.ToList();
        }
        public static List<Product> ProductsListOfSpecificCustomer(int customerCode)
        {
            var productList =
                from item in customerProducts
                where item.Person.Code == customerCode
                select item.Product;
            if (productList is null)
                throw new Exception("This customer has no products");

            return productList.ToList();
        }

        public static List<Product> ProductsListOfSpecificDealer(int code)
        {
            var productList =
                from item in customerProducts
                where item.ShopName.EconomicCode == code
                select item.Product;

            if (productList is null)
                throw new Exception("This dealer hasn't any products");

            return productList.ToList();
        }
        public static void DealersSales()
        {
            int sales = 0;
            foreach (var shop in dealers)
            {
                foreach (var item in customerProducts)
                {
                    if (item.ShopName == shop)
                        sales = sales + (item.Quantity * item.Product.Price);
                }
                Console.WriteLine("{0}, Total Sales: {1}$", shop.DealerName, sales);
                sales = 0;
            }

            Console.ReadKey();
        }
        public static void ProductSales(int code)
        {
            Product product = Product.ReturnProduct(code);

            var productSales =
                from item in customerProducts
                where item.Product.Code == code
                select item.Quantity;

            if (productSales.Sum() == 0)
                throw new Exception("this product has been never bought before !");

            Console.WriteLine("{0}, Total sales: {1}", product, productSales.Sum());
            Console.ReadKey();
        }


    }
}
