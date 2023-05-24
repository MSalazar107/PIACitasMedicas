using Microsoft.AspNetCore.Mvc.Filters;

namespace CitasMedicas.Filtros
{
    public class FiltroDeAccion
    {
        private readonly ILogger<FiltroDeAccion> log;

        public FiltroDeAccion(ILogger<FiltroDeAccion> log)
        {
            this.log = log;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            log.LogInformation("Antes de ejecutar la accion");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            log.LogInformation("Despues de ejecutar la accion");
        }
    }
}
