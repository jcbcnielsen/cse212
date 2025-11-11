/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: 1 max customer, add 2 customers, serve 2 customers
        // Expected Result: second customer addition rejected, display first customer details and an error for the second serve attempt
        Console.WriteLine("Test 1");
        CustomerService cs1 = new CustomerService(1);
        cs1.AddNewCustomer();
        cs1.AddNewCustomer();
        cs1.ServeCustomer();
        cs1.ServeCustomer();

        // Defect(s) Found: Item in queue was removed before being read, size of queue was able to be larger than intended, no error would display if queue was empty when attempting to serve

        Console.WriteLine("=================");

        // Test 2
        // Scenario: -1 max customer, add 11 customers, serve 11 customers
        // Expected Result: corrects to default of 10 max customers, 11th customer rejected, display first 10 customers and an error for the 11th serve attempt
        Console.WriteLine("Test 2");
        CustomerService cs2 = new CustomerService(-1);
        for (int i = 1; i <= 9; i++)
        {
            cs2._queue.Add(new Customer($"Customer{i}", $"Id{i}", $"Problem{1}"));
        }
        cs2.AddNewCustomer();
        cs2.AddNewCustomer();
        for (int i = 0; i < 11; i++)
        {
            cs2.ServeCustomer();
        }

        // Defect(s) Found: none, all were detected in testing by running Test 1

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) { // fixed from only checking if the size of the queue was greater than the max size
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count < 1) // fixed from having no error message if queue was empty
        {
            Console.WriteLine("There are no customers to serve in the Queue.");
            return;
        }
        var customer = _queue[0]; // fixed from removing the item before reading it
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}