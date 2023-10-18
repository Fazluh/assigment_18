using System;
using System.Collections.Generic;

public class Movie
{
    public int MovieID { get; set; }
    public string MovieName { get; set; }
    public string Language { get; set; }
}

public class Customer
{
    public int CustID { get; set; }
    public DateTime BorrowDate { get; set; }
    public int MovieID { get; set; }
    public DateTime? ReturnDate { get; set; }

    public Customer()
    {
        CustID = GenerateUniqueCustomerID();
    }

    public void Borrow(Movie movie)
    {
        if (movie == null)
        {
            throw new ArgumentNullException("Movie cannot be null.");
        }

        if (BorrowDate == DateTime.Now)
            {
            throw new InvalidOperationException("BorrowDate must be set before borrowing.");
        }

        if (ReturnDate != null)
        {
            throw new InvalidOperationException("ReturnDate must be null when borrowing.");
        }

        MovieID = movie.MovieID;
        ReturnDate = BorrowDate.AddDays(10);
    }

    public static int GenerateUniqueCustomerID()
    {
    //creating random customer id
        return new Random().Next(1000, 9999);
    }
}

public class MovieRentalSystem
{
    private List<Customer> customers = new List<Customer>();
    private List<Movie> movies = new List<Movie>();
    private List<Customer> overdueMovies = new List<Customer>();

    public void AddCustomer(Customer customer)
    {
        if (customer == null)
        {
            throw new ArgumentNullException("Customer cannot be null.");
        }
        customers.Add(customer);
    }

    public void AddMovie(Movie movie)
    {
        if (movie == null)
        {
            throw new ArgumentNullException("Movie cannot be null.");
        }
        movies.Add(movie);
    }

    public void CheckForOverdueMovies()
    {
        DateTime currentDate = DateTime.Now;

        foreach (Customer customer in customers)
        {
            if (customer.ReturnDate.HasValue && currentDate > customer.ReturnDate)
            {
                overdueMovies.Add(customer);
            }
        }

        if (overdueMovies.Count > 0)
        {
            Console.WriteLine("Overdue Movies:");
            foreach (var customer in overdueMovies)
            {
                Console.WriteLine($"Customer ID: {customer.CustID}, Movie ID: {customer.MovieID}");
            }
        }
        else
        {
            Console.WriteLine("No overdue movies found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MovieRentalSystem rentalSystem = new MovieRentalSystem();

        try
        {
            Movie movie1 = new Movie { MovieID = 1, MovieName = "FastX", Language = "English" };
            Movie movie2 = new Movie { MovieID = 2, MovieName = "Black Adam", Language = "Spanish" };

            rentalSystem.AddMovie(movie1);
            rentalSystem.AddMovie(movie2);

            Customer customer1 = new Customer();
            Customer customer2 = new Customer();
            Customer customer3 = new Customer();

            rentalSystem.AddCustomer(customer1);
            rentalSystem.AddCustomer(customer2);
            rentalSystem.AddCustomer(customer3);

            customer1.Borrow(movie1);

            Console.WriteLine($"Customer 1 - BorrowDate: {customer1.BorrowDate}, ReturnDate: {customer1.ReturnDate}, MovieName = {movie1.MovieName}");
            Console.WriteLine($"Customer 2 - BorrowDate: {customer2.BorrowDate}, ReturnDate: {customer2.ReturnDate}");

            rentalSystem.CheckForOverdueMovies();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Console.WriteLine(ex.Message);
        }
        Console.ReadLine();
    }
}
