using System;
using System.Data;
using System.Web;
using System.Web.Mail;
using CMSNET.Common;
using CMSNET.DataAccess;

namespace CMSNET.Common
{
	/// <summary>
	/// Summary description for EmailAlert.
	/// </summary>
	public class EmailAlert
	{
		private int m_code;
		private int m_towho;
		private string m_body = "";
		private	HttpContext m_context;

		public int Code
		{
			get { return m_code;  }
			set { m_code = value; }
		}

		public int ToWho
		{
			get { return m_towho;  }
			set { m_towho = value; }
		}

		public string Body
		{
			get { return m_body;  }
			set { m_body = value; }
		}

		public EmailAlert(HttpContext context, int code, int towho)
		{
			m_context = context;
			m_code  = code;
			m_towho = towho;
		}

		public void Send()
		{
			 	AppEnv appenv = new AppEnv(m_context);

				string SMTPServer = appenv.GetAppSetting("smtpserver").Trim();
				if (SMTPServer.Length <= 0)
					return;  // do not use email notifications

				SmtpMail.SmtpServer = SMTPServer;

				Account account = new Account(appenv.GetConnection());

				MailMessage mail = new MailMessage();

				DataRow dr = account.GetAccountForID(1); // Admin account
				mail.From = dr["Email"].ToString().Trim();

				mail.Subject = generateSubject();
				mail.Body = m_body;
				mail.BodyFormat = MailFormat.Text;

				if (m_towho != 0)
				{
					dr = account.GetAccountForID(m_towho); 
					mail.To = dr["Email"].ToString().Trim();
					try
					{
						SmtpMail.Send(mail);
					}
					catch
					{
					}
				}
				else
				{
					AccountRoles roles = new AccountRoles(new AppEnv(m_context).GetConnection());
					DataTable dt = roles.GetAllRole(getRoleForCode());

					foreach (DataRow drr in dt.Rows)
					{
						dr = account.GetAccountForID(Convert.ToInt32(drr["AccountID"])); 
						mail.To = dr["Email"].ToString().Trim();
						try
						{
							SmtpMail.Send(mail);
						}
						catch
						{
						}
					}
				} 			 
		}

		private string getRoleForCode()
		{
			switch (m_code)
			{
				case StatusCodes.RequiresUpdate:
					return "Author";

				case StatusCodes.AwaitingEdit:
				case StatusCodes.Editing:
				case StatusCodes.RequiresEditing:
					return "Editor";

				case StatusCodes.AwaitingApproval:
					return "Approver";

				case StatusCodes.Approved:
					return "Deployer";

				default:
					return "";
			}
		}

		private string generateSubject()
		{
			switch (m_code)
			{
				case StatusCodes.AwaitingEdit:
					return "New content available for editing";

				case StatusCodes.Editing:
					return "Updated content available for editing";

				case StatusCodes.AwaitingApproval:
					return "Content available for approval";

				case StatusCodes.RequiresUpdate:
					return "Content require updating";

				case StatusCodes.RequiresEditing:
					return "Content require editing";

				case StatusCodes.Approved:
					return "Content available for deployment";

				case StatusCodes.Discontinued:
					return "Content has been discontinued";

				default:
				    return "";
			}
		}
	}
}
