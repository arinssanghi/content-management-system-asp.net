using System;

namespace CMSNET.Common
{
	/// <summary>
	/// Summary description for StatusCodes.
	/// </summary>
	public class StatusCodes
	{
		public StatusCodes()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public const int None             = 0x00000000;
        public const int Creating         = 0x00000001;
        public const int AwaitingEdit     = 0x00000002;
        public const int RequiresUpdate   = 0x00010001;
        public const int Editing          = 0x00000004;
        public const int AwaitingApproval = 0x00000008;
        public const int RequiresEditing  = 0x00010004;
        public const int Approving        = 0x00000010;
        public const int Approved         = 0x00000020;
        public const int Deployed         = 0x00000040;
		public const int Archived         = 0x00000080;
		public const int Discontinued     = 0x00100000;

        public static string ToString(int val)
        {
            switch (val)
            {
                case Creating:
                    return "Creating";
                case AwaitingEdit:
                    return "Awaiting Edit";
                case RequiresUpdate:
                    return "Requires Update";
                case Editing:
                    return "Editing";
                case AwaitingApproval:
                    return "Awaiting Approval";
                case RequiresEditing:
                    return "Requires Editing";
                case Approving:
                    return "Approving";
                case Approved:
                    return "Approved";
                case Deployed:
                    return "Deployed";
				case Archived:
					return "Archived";
				case Discontinued:
					return "Discontinued";
				default:
                    return "None";
            }
        }

        public static bool isCreating(string val)
        {
            return (Convert.ToInt32(val) & Creating) == Creating;
        }
        public static bool isAwaitingEdit(string val)
        {
            return (Convert.ToInt32(val) & AwaitingEdit) == AwaitingEdit;
        }
        public static bool isRequiresUpdate(string val)
        {
            return (Convert.ToInt32(val) & RequiresUpdate) == RequiresUpdate;
        }
        public static bool isEditing(string val)
        {
            return (Convert.ToInt32(val) & Editing) == Editing;
        }
        public static bool isAwaitingApproval(string val)
        {
            return (Convert.ToInt32(val) & AwaitingApproval) == AwaitingApproval;
        }
        public static bool isRequiresEditing(string val)
        {
            return (Convert.ToInt32(val) & RequiresEditing) == RequiresEditing;
        }
        public static bool isApproving(string val)
        {
            return (Convert.ToInt32(val) & Approving) == Approving;
        }
        public static bool isApproved(string val)
        {
            return (Convert.ToInt32(val) & Approved) == Approved;
        }
        public static bool isDeployed(string val)
        {
            return (Convert.ToInt32(val) & Deployed) == Deployed;
        }
        public static bool isArchived(string val)
        {
            return (Convert.ToInt32(val) & Archived) == Archived;
        }
    }
}
