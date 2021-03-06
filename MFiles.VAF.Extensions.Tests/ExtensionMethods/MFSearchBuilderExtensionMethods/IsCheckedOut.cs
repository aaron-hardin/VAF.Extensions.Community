﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFilesAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MFiles.VAF.Extensions.Tests.ExtensionMethods.MFSearchBuilderExtensionMethods
{
	[TestClass]
	public class IsCheckedOut
		: MFSearchBuilderExtensionMethodTestBase
	{
		/// <summary>
		/// Tests that calling
		/// <see cref="MFSearchBuilderExtensionMethods.IsCheckedOut(Common.MFSearchBuilder, bool)"/>
		/// adds a search condition.
		/// </summary>
		[TestMethod]
		public void AddsSearchCondition()
		{
			// Create the search builder.
			var mfSearchBuilder = this.GetSearchBuilder();

			// Ensure it has no items in the collection.
			Assert.AreEqual(0, mfSearchBuilder.Conditions.Count);

			// Add the search condition for whether the object is checked out.
			mfSearchBuilder.IsCheckedOut();

			// Ensure that there is one item in the collection.
			Assert.AreEqual(1, mfSearchBuilder.Conditions.Count);
		}
		
		/// <summary>
		/// Tests that calling
		/// <see cref="MFSearchBuilderExtensionMethods.IsCheckedOut(Common.MFSearchBuilder, bool)"/>
		/// adds a valid search condition with a true argument.
		/// </summary>
		[TestMethod]
		public void SearchConditionIsCorrect_True()
		{
			// Create the search builder.
			var mfSearchBuilder = this.GetSearchBuilder();

			// Add the search condition for whether the object is checked out.
			mfSearchBuilder.IsCheckedOut(true);

			// If there's anything other than one condition then fail.
			if (mfSearchBuilder.Conditions.Count != 1)
				Assert.Inconclusive("Only one search condition should exist");

			// Retrieve the just-added condition.
			var condition = mfSearchBuilder.Conditions[mfSearchBuilder.Conditions.Count];

			// Ensure the condition type is correct.
			Assert.AreEqual(MFConditionType.MFConditionTypeEqual, condition.ConditionType);

			// Ensure the expression type is correct.
			Assert.AreEqual(MFExpressionType.MFExpressionTypeStatusValue, condition.Expression.Type);

			// Ensure the status value is correct.
			Assert.AreEqual(MFStatusType.MFStatusTypeCheckedOut, condition.Expression.DataStatusValueType);

			// Ensure that the typed value is correct.
			Assert.AreEqual(MFDataType.MFDatatypeBoolean, condition.TypedValue.DataType);
			Assert.AreEqual(true, condition.TypedValue.Value as bool?);
		}
		
		/// <summary>
		/// Tests that calling
		/// <see cref="MFSearchBuilderExtensionMethods.IsCheckedOut(Common.MFSearchBuilder, bool)"/>
		/// adds a valid search condition with a false argument.
		/// </summary>
		[TestMethod]
		public void SearchConditionIsCorrect_False()
		{
			// Create the search builder.
			var mfSearchBuilder = this.GetSearchBuilder();

			// Add the search condition for whether the object is checked out.
			mfSearchBuilder.IsCheckedOut(false);

			// If there's anything other than one condition then fail.
			if (mfSearchBuilder.Conditions.Count != 1)
				Assert.Inconclusive("Only one search condition should exist");

			// Retrieve the just-added condition.
			var condition = mfSearchBuilder.Conditions[mfSearchBuilder.Conditions.Count];

			// Ensure the condition type is correct.
			Assert.AreEqual(MFConditionType.MFConditionTypeEqual, condition.ConditionType);

			// Ensure the expression type is correct.
			Assert.AreEqual(MFExpressionType.MFExpressionTypeStatusValue, condition.Expression.Type);

			// Ensure the status value is correct.
			Assert.AreEqual(MFStatusType.MFStatusTypeCheckedOut, condition.Expression.DataStatusValueType);

			// Ensure that the typed value is correct.
			Assert.AreEqual(MFDataType.MFDatatypeBoolean, condition.TypedValue.DataType);
			Assert.AreEqual(false, condition.TypedValue.Value as bool?);
		}

	}
}
