using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkOrder workOrder = new WorkOrder();

            try
            {
                Console.WriteLine($"Initial: {workOrder.ShowStatus()}");

                // Test valid rollback
                workOrder.SetStatus("Created");
                Console.WriteLine($"After Created: {workOrder.ShowStatus()}");

                workOrder.SetStatus("Progress");
                Console.WriteLine($"After Progress: {workOrder.ShowStatus()}");

                // Test the invalid rollback
                workOrder.SetStatus("Created");

                Console.WriteLine("All operations completed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
