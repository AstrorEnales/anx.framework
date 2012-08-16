﻿using System;
using System.Collections.Generic;

namespace HLSLParser
{
	public class Structure
	{
		#region Public
		public string Name
		{
			get;
			private set;
		}

		public List<Variable> Variables
		{
			get;
			private set;
		}
		#endregion
		
		#region Constructor
		public Structure(ParseTextWalker walker)
		{
			Variables = new List<Variable>();

			string currentText = walker.Text;

			int indexOfStructOpenBrace = currentText.IndexOf('{');
			walker.Seek(indexOfStructOpenBrace + 1);

			Name = currentText.Substring(0, indexOfStructOpenBrace);
			Name = Name.Replace("struct ", "").Trim();

			Variable newVariable = null;
			while ((newVariable = Variable.ParseIfVariable(walker)) != null)
			{
				Variables.Add(newVariable);
			}

			currentText = walker.Text;
			int indexOfStructCloseBrace = currentText.IndexOf("};");
			walker.Seek(indexOfStructCloseBrace + 2);
		}
		#endregion
		
		#region ParseIfStructure
		public static Structure ParseIfStructure(ParseTextWalker walker)
		{
			string currentText = walker.Text;
			if (currentText.StartsWith("struct"))
			{
				return new Structure(walker);
			}

			return null;
		}
		#endregion
	}
}