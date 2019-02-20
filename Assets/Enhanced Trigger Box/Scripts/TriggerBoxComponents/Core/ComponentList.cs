using EnhancedTriggerbox.Component;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnhancedTriggerbox
{
    public class ComponentList
    {
       // public string[] conditionNames;

      //  public string[] responseNames;

        public List<string> conditionNames;
        public List<string> responseNames;

        private static ComponentList instance;

        public static ComponentList Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ComponentList();
                }

                return instance;
            }
        }

        /// The constructor that uses reflection to find all instances of condition/response components and returns them as an array of strings.
        private ComponentList()
        {
            // Get all the names of the assemblies which inherit ConditionComponent
            string[] listOfComponents =
                (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.GlobalAssemblyCache)
                    from assemblyType in domainAssembly.GetTypes()
                    where typeof(ConditionComponent).IsAssignableFrom(assemblyType) &&
                          assemblyType.Name != "ConditionComponent"
                    select EnhancedTriggerBox.AddSpacesToSentence(assemblyType.Name, true)).ToArray();

            // Add the Select A Condition/Response items to the list so they're displayed at the top. Is this the best way to do this?
            var newArray = new string[listOfComponents.Length + 1];
            listOfComponents.CopyTo(newArray, 1);
            newArray[0] = "Select A Condition";
            conditionNames = newArray.ToList();

            listOfComponents =
                (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.GlobalAssemblyCache)
                    from assemblyType in domainAssembly.GetTypes()
                    where typeof(ResponseComponent).IsAssignableFrom(assemblyType) &&
                          assemblyType.Name != "ResponseComponent"
                    select EnhancedTriggerBox.AddSpacesToSentence(assemblyType.Name, true)).ToArray();

            newArray = new string[listOfComponents.Length + 1];
            listOfComponents.CopyTo(newArray, 1);
            newArray[0] = "Select A Response";
            responseNames = newArray.ToList();
        }
    }
}