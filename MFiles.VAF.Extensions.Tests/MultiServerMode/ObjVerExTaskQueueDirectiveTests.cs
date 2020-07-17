using MFiles.VAF.Common;
using MFiles.VAF.Extensions.MultiServerMode;
using MFilesAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MFiles.VAF.Extensions.Tests.MultiServerMode
{
	[TestClass]
	public class ObjVerExTaskQueueDirectiveTests
	{
		[TestMethod]
		public void ObjVerStringIsReadWrite()
		{
			var type = typeof(ObjVerExTaskQueueDirective);
			var property = type.GetProperty(nameof(ObjVerExTaskQueueDirective.ObjVerString));
			Assert.IsNotNull(property);
			Assert.IsTrue(property.CanRead);
			Assert.IsTrue(property.CanWrite);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void FromObjVerThrowsIfArgumentNull()
		{
			ObjVerExTaskQueueDirective.FromObjVer(null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void FromObjVerExThrowsIfArgumentNull()
		{
			ObjVerExTaskQueueDirective.FromObjVerEx(null);
		}

		[TestMethod]
		public void FromObjVerCorrectString()
		{
			var objVer = new ObjVer();
			objVer.SetIDs(0, 1, 2);
			Assert.AreEqual
			(
				"(0-1-2)",
				ObjVerExTaskQueueDirective.FromObjVer(objVer).ObjVerString
			);
		}

		[TestMethod]
		public void ToObjVerCorrect()
		{
			var objVer = new ObjVer();
			objVer.SetIDs(0, 1, 2);
			Assert.AreEqual
			(
				"(0-1-2)",
				ObjVerExTaskQueueDirective.FromObjVer(objVer).ToObjVer().ToString(true)
			);
		}
	}
}
