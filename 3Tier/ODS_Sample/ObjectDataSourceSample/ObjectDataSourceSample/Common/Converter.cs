using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DevExpress.Data.Filtering;

namespace ObjectDataSourceSample.Common
{
    public class Converter
    {
        public static ArrayList FilterExpressionToArrayList(string filterExpression)
        {
            ArrayList arrayList = new ArrayList();

            CriteriaOperator criteriaOperator = CriteriaOperator.Parse(filterExpression);

            if (criteriaOperator is GroupOperator)
            {
                var groupOperator = (GroupOperator)criteriaOperator;

                foreach (var operand in groupOperator.Operands)
                {
                    object result = ExtractOperandToFilter(operand);
                    arrayList.Add(result);
                }
            }
            else
            {
                object result = ExtractOperandToFilter(criteriaOperator);
                arrayList.Add(result);
            }

            return arrayList;
        }
        private static object ExtractOperandToFilter(CriteriaOperator operand)
        {
            object[] result = null;
            if (operand is BinaryOperator)
            {
                var binaryOperator = (BinaryOperator)operand;
                result = new object[] { binaryOperator.OperatorType, binaryOperator.LeftOperand, binaryOperator.RightOperand };
            }
            else if (operand is FunctionOperator)
            {

                var functionOperator = (FunctionOperator)operand;
                result = new object[] { functionOperator.OperatorType, functionOperator.Operands[0].ToString(), functionOperator.Operands[1].ToString() };
            }
            else if (operand is UnaryOperator)
            {
                var unaryOperator = (UnaryOperator)operand;
                var functionOperator = (FunctionOperator)unaryOperator.Operand;
                result = new object[] { unaryOperator.OperatorType, functionOperator.Operands[0].ToString(), functionOperator.Operands[1].ToString() };
            }
            else if (operand is BetweenOperator)
            {

            }
            else if (operand is InOperator)
            {

            }
            else if (operand is NotOperator)
            {

            }
            else if (operand is NullOperator)
            {

            }
            else if (operand is ContainsOperator)
            {

            }

            return result;
        }
    }
}