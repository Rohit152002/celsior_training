using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace Doctor
{
    internal class Program
    {
        static Doctor[] doctors;
        static void TakingUserInput(int n)
        {
            doctors=new Doctor[n];
            for(int i = 0; i < n; i++)
            {
                doctors[i] = new Doctor();
                try
                {
                Console.WriteLine($"Enter Detail for Doctor {i+1}");
               Console.Write("Name : ");
                doctors[i].Name=Console.ReadLine();

                Console.Write("Specialization : ");
                doctors[i].Specialization = Console.ReadLine();

                Console.Write("Hospital : ");
                doctors[i].Hospital = Console.ReadLine();

                //Console.Write("Experience : ");
                    bool validExperience = false;
                    while (!validExperience)
                    {
                        Console.Write("Experience (in years): ");
                        try
                        {
                            doctors[i].Experience = Convert.ToInt32(Console.ReadLine());
                            if (doctors[i].Experience < 0)
                            {
                                throw new ArgumentOutOfRangeException("Experience cannot be negative.");
                            }
                            validExperience = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid format. Please enter a valid number.");
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Unexpected error: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while inputting doctor details: " + ex.Message);
                }

            }
        }
        static void PrintDoctors()
        {
            if(doctors == null)
            {
                Console.WriteLine("There is no Doctors created");
                return;
            }
            for (int i=0;i<doctors.Length;i++)
            {
                Console.WriteLine($"{i+1}. Name = {doctors[i].Name}, Specialization = {doctors[i].Specialization} , Experience = {doctors[i].Experience}, Hospital = {doctors[i].Hospital}");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter the no. of doctor that you want to create : ");
            try
            { 
                int n= Convert.ToInt32(Console.ReadLine());
                if (n<1)
                {
                    throw new ValueZeroError("it should be greater than 0 ");
                }
                TakingUserInput(n);
            } catch (FormatException e)
            {
                Console.WriteLine("Enter a integer digits");
            } catch ( OverflowException e)
            {
                Console.WriteLine("the value should be between 1-9999");
            }
            catch(ValueZeroError e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                                PrintDoctors();
                                
            }   
        }
    }
}
