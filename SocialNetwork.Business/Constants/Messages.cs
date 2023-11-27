namespace SocialNetwork.Business.Constants
{
    public static class Messages
    {
        // Successfully basic
        public static string CreatedSuccessfully => "Created successfully";
        public static string DeletedSuccessfully => "Deleted successfully";
        public static string UpdatedSuccessfully => "Updated sucessfully";
        public static string GetSuccessfully => "Get successfully";


        // Error basic
        public static string AddError => "Error create";
        public static string UpdateError => "Error update";
        public static string DeleteError => "Error delete";
        public static string NotFound => "Resources not found";
        public static string NotFounb(string resource) => $"{resource} not found";
        
        // Reaction
        public static string ReactionExist => "Name and Code are already exist";

        // User
        public static string LoginSuccessfully => "Login successfully";
        public static string RegistrationSucessfully => "Registration successfully";
        public static string AddRoleToUserSuccess => "Add roles to user successfully";
        public static string EmailUsed => "Email is used";
        public static string IncorrectEP => "Incorrect email or password";

        // Role
        public static string RoleEmpty => "Roles is empty";
        public static string InvalidRole => "Invalid role";
        public static string RoleExist => "Role already exits";

        // Post
        public static string PostNotOwner => "This user is not the owner";
    }
}
