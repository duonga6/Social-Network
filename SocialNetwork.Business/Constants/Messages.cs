namespace SocialNetwork.Business.Constants
{
    public static class Messages
    {
        // Successfully basic
        public static string CreatedSuccessfully => "Created successfully";
        public static string DeletedSuccessfully => "Deleted successfully";
        public static string UpdatedSuccessfully => "Updated successfully";
        public static string GetSuccessfully => "Get successfully";


        // Error basic
        public static string AddError => "Error create";
        public static string UpdateError => "Error update";
        public static string DeleteError => "Error delete";
        public static string NotFound() => "Not found";
        public static string NotFound(string resource) => $"{resource} not found";
        public static string UnAuthorized => "Unauthorized";
        public static string BadRequest => "Bad Request";
        public static string Forbidden => "Forbidden";
        public static string STWrong => "Something went wrong";
        public static string OutOfPage => "The page number is out of page range";
        public static string EmailSent => "Email sent";
        public static string PermissionDenied(string resource = "") => "Permission denied " + resource;

        // Reaction
        public static string ReactionExist => "Name and Code are already exist";
        public static string PostReactionExist => "This user has already added a reaction for this post";
        public static string CommentReactionExist => "This user has already added a reaction for this comment";

        // User
        public static string LoginSuccessfully => "Login successfully";
        public static string RegistrationSuccessfully => "Registration successfully";
        public static string AddRoleToUserSuccess => "Add roles to user successfully";
        public static string EmailUsed => "Email đã được sử dụng";
        public static string IncorrectEP => "Incorrect email or password";
        public static string GetCodeResetPassword = "Get code reset password successfully";
        public static string ResetPasswordSuccessfully = "Password has been reset";
        public static string ResetPasswordError = "Reset password fail";
        public static string ConfirmEmailSuccess = "Confirm email successfully";
        public static string GetCodeConfirmEmailSuccess = "Get code confirm email successfully";
        public static string ChangePasswordSuccessfully = "Change password successfully";

        // Role
        public static string RoleEmpty => "Roles is empty";
        public static string InvalidRole => "Invalid role";
        public static string RoleExist => "Role already exits";

        // Post
        public static string PostNotOwner => "Is not the owner";
        public static string PostEmpty => "Content or media must not empty";

        // Post reaction
        public static string NotOwnerPostReaction => "You are not the owner post's reaction";

        // Comment 
        public static string CommentNotOwner => "Is not the owner";

        // Comment reaction
        public static string NotOwnerCommentReaction => "You are not the owner comment's reaction";

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
        public static string MessageRevoked => "Revoked message successfully";
        public static string MessageSeen => "Seen message";

        // Notification
        public static string NotificationSeen => "Notification has been seen";


        // Group
        public static string CreatedRequestJoinGroup => "GA01 Created join group request";
        public static string GroupMemberJoined => "GA02 Joined group";
        public static string GroupAcceptedInviteFromOther => "GA03 Accepted invite request from other user";
        public static string GroupJoinRequestExist => "GF01 User already send request join group";
        public static string GroupAccessDenied => "GF02 Access denied to group";
        public static string GroupMemberExist => "GF03 User is already joined group";
        public static string AcceptedInvite(string who) => $"GA04{who} accepted invite";
    }
}
