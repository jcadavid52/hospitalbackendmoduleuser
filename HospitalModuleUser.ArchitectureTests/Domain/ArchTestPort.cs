using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace HospitalModuleUser.ArchitectureTests.Domain
{
    public class ArchTestPort
    {
        private static readonly Architecture Architecture = new ArchLoader().LoadAssemblies(
           System.Reflection.Assembly.Load("HospitalModuleUser.Domain")
       ).Build();

        [Fact]
        public void LosRepositoriosDebenTerminarConRepository()
        {
            var portNamespacePattern = "HospitalModuleUser.Domain.*.Port.InterfacesRepositories";

            Interfaces()
            .That()
            .ResideInNamespace(portNamespacePattern, true)
            .Should()
            .HaveNameEndingWith("Repository")
            .Because("Los repositorios en la capa de dominio deben tener nombres que terminen con 'Repository'")
            .Check(Architecture);
        }
    }
}
