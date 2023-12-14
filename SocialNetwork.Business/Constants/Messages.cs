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
        public static string NotFound => "Not found";
        public static string NotFounb(string resource) => $"{resource} not found";
        public static string UnAuthorized => "Unauthorized";
        public static string BadRequest => "Bad Request";
        public static string Forbidden => "Forbidden";
        public static string STWroong => "Something went wrong";

        // Reaction
        public static string ReactionExist => "Name and Code are already exist";
        public static string PostReactionExist => "This user has already added a reaction";
        public static string CommentReactionExist => "This user has already added a reaction";

        // User
        public static string LoginSuccessfully => "Login successfully";
        public static string RegistrationSucessfully => "Registration successfully";
        public static string AddRoleToUserSuccess => "Add roles to user successfully";
        public static string EmailUsed => "Email is used";
        public static string IncorrectEP => "Incorrect email or password";
        public static string GetCodeResetPassword = "Get code reset password successfully";
        public static string ResetPasswordSuccesfully = "Password has been reset";
        public static string ResetPasswordError = "Reset password fail";
        public static string ConfirmEmailSuccess = "Confirm email successfully";
        public static string GetCodeConfirmEmailSuccess = "Get code confirm email successfully";

        // Role
        public static string RoleEmpty => "Roles is empty";
        public static string InvalidRole => "Invalid role";
        public static string RoleExist => "Role already exits";

        // Post
        public static string PostNotOwner => "Is not the owner";

        // Comment 
        public static string CommentNotOwner => "Is not the owner";

        // Friendship
        public static string FriendshipExisted => "Friendship existed";
        public static string FriendshipSent => "Send request successfully";
        public static string FriendshipStatusInValid => "Friendship status invalid";
        public static string FriendshipAccepted => "Friendship accepted";
        public static string FriendshipBlocked => "User blocked";
        public static string FriendshipUnblocked => "User unblocked";
        public static string FriendshipCanceled => "Friendship canceled";
        public static string FriendshipRefused => "Refused friend request";
        public static string FriendshipUnfriended => "Unfriended";
        public static string NotFriend => "Friends required";

        // Message
        public static string MessageSent => "Send message successfully";
        public static string MessageDeleted => "Delete message successfully";
    }
}
