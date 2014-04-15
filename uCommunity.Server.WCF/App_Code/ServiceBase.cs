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
        this.Entities = new uCommunityEntities();	
	}

    protected uCommunityEntities Entities { get; private set; }
}