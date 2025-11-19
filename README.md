Rollback Prevention Report

I have developed a program that solves the invalid rollback problem.

The solution utilizes the IStatusValidator interface, which contains a single method called SetStatus.

Now, let's look at the OrderStatus class. This class includes several components: a CurrentStatus field, a Status enumerator, and two methods (SetStatus and ShowStatus).

I chose to use an enumerator for the Status because it provides an easy way to compare different statuses. The enumerator includes all possible statuses, from Draft to Completed. Each status corresponds to a unique numeric value.

Now, let's examine the SetStatus method in more detail. This method takes a single string parameter called newStatus.

Its logic is as follows:

1) It checks if the newStatus string is a valid value from the Status enumerator. If not, an exception is thrown.

2) The string value is then parsed into the corresponding enum value for comparison.

3) The parsed newStatus is compared against the business rules. If the transition to the new status is valid, the CurrentStatus field is updated. If the newStatus is invalid or identical to the CurrentStatus, an exception is thrown.

Finally, the ShowStatus method returns a string representation of the CurrentStatus field.
