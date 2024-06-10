namespace Shared.Constants;

public enum AccountType : byte
{
    // This exists for the possibility to create a user and assign an account type after creation
    Undefined = 0,

    Operations = 1,

    InformationTechnology = 2
}
