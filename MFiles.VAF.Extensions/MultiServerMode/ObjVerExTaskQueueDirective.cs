using MFiles.VAF.Common;
using MFiles.VAF.MultiserverMode;
using MFilesAPI;
using System;

namespace MFiles.VAF.Extensions.MultiServerMode
{
	/// <summary>
	/// A <see cref="TaskQueueDirective"/> that represents a single <see cref="ObjVerExTaskQueueDirective.ObjVerEx"/>.
	/// </summary>
	public class ObjVerExTaskQueueDirective
		: TaskQueueDirective
	{
		/// <summary>
		/// Parse-able ObjVer string.
		/// </summary>
		public string ObjVerString { get; set; }

		/// <summary>
		/// Returns an instance of the <see cref="ObjVer"/>
		/// represented by <see cref="ObjVerString"/>.
		/// </summary>
		/// <returns></returns>
		public ObjVer ToObjVer()
		{
			try
			{
				return MFUtils.ParseObjVerString(this.ObjVerString);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// Returns an instance of the <see cref="ObjVer"/>
		/// represented by <see cref="ObjVerString"/>.
		/// </summary>
		/// <returns></returns>
		public ObjVerEx ToObjVerEx(Vault vault)
		{
			// Sanity.
			if (null == vault)
				throw new ArgumentNullException(nameof(vault));

			// Get the objver.
			var objVer = this.ToObjVer();
			if(null == objVer)
				return null;

			// Create the objverex
			return new ObjVerEx(vault, objVer);
		}

		/// <summary>
		/// Creates a <see cref="ObjVerExTaskQueueDirective"/>
		/// representing the provided <paramref name="objVer"/>.
		/// </summary>
		/// <param name="objVer">The object version to represent.</param>
		/// <returns>The task queue directive for the supplied object version.</returns>
		public static ObjVerExTaskQueueDirective FromObjVer(ObjVer objVer)
		{
			// Sanity.
			if (null == objVer)
				throw new ArgumentNullException(nameof(objVer));

			return new ObjVerExTaskQueueDirective()
			{
				ObjVerString = objVer.ToString(parsable: true)
			};
		}
		
		/// <summary>
		/// Creates a <see cref="ObjVerExTaskQueueDirective"/>
		/// representing the provided <paramref name="objVerEx"/>.
		/// </summary>
		/// <param name="objVerEx">The object version to represent.</param>
		/// <returns>The task queue directive for the supplied object version.</returns>
		public static ObjVerExTaskQueueDirective FromObjVerEx(ObjVerEx objVerEx)
		{
			// Sanity.
			if (null == objVerEx)
				throw new ArgumentNullException(nameof(objVerEx));

			// Use the other method.
			return ObjVerExTaskQueueDirective.FromObjVer(objVerEx.ObjVer);
		}
	}
}
