using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediSync {



     public class TypeEvaluation {

        public enum CrmType {
            STRING, INT32, UNIQUEIDENTIFIER
        }

        public TypeEvaluation() {

        }

        public CrmType GetType(Object obj) {
            CrmType type = CrmType.STRING;

            switch (obj.GetType().ToString()) {
                case "Byte":
                   
                    break;

                case "Char":

                    break;

                case "DateTime":

                    break;

                case "Decimal":

                    break;

                case "Double":

                    break;

                case "Int16":

                    break;

                case "Int32":

                    break;

                case "Int64":

                    break;

                case "SByte":

                    break;

                case "Single":

                    break;

                case "String":

                    break;

                case "TimeSpan":

                    break;

                case "UInt16":
                    
                    break;

                case "UInt32":

                    break;

                case "UInt64":

                    break;
                default:
                    return type;
            }

            return type;
        }

    }
}
