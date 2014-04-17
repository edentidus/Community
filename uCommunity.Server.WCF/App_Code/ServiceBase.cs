using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uCommunity.Server.Data;

/// <summary>
/// Summary description for ServiceBase
/// </summary>
public class ServiceBase
{
	public ServiceBase()
	{
	}

    protected ResultWrapper<T> TryDo<T>(Func<uCommunityEntities, T> func)
    {
        ResultWrapper<T> retval = new ResultWrapper<T>();
        try
        {
            using (uCommunityEntities entities = new uCommunityEntities())
            {
                retval.Result = func(entities);
            }
        }
        catch(Exception ex)
        {
            retval.HasError = true;
            retval.ErrorMessage = ex.Message;
        }

        return retval;
    }
}