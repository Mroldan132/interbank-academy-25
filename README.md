# README - Proyecto Prueba Técnica

## Introducción
Este proyecto es una solución técnica diseñada para procesar transacciones financieras y generar reportes con información relevante como el balance final, la transacción de mayor monto y el conteo de transacciones por tipo (crédito/débito).
## Instrucciones de Ejecución
1. **Requisitos previos**:
   - .NET Core SDK (versión compatible con el proyecto)
   - IDE de preferencia (Visual Studio, VS Code, etc.)

2. **Instalación**:
   - Clonar el repositorio
   - No se requieren dependencias externas adicionales

3. **Ejecución**:
   - Compilar y ejecutar el proyecto desde tu IDE

## Enfoque y Solución
**Lógica implementada**:
- Se utilizó una arquitectura por capas con separación clara de responsabilidades
- Interfaces para definir contratos (IReporteGenerador, ITransaccionLoader)
- Modelos bien definidos para representar entidades (Transaccion, Reporte)
- Enfoque SOLID, especialmente principio de inversión de dependencias

**Decisiones de diseño**:
- Uso de enum `TipoTransaccion` para garantizar consistencia en los tipos
- Métodos específicos para cada cálculo requerido en el reporte
- Diccionario para el conteo de transacciones por tipo por su eficiencia en búsquedas

## Estructura del Proyecto

```markdown
📦 Prueba_Tecnica
├── 📂 Data                  → Datos a consumir
│   ├── data.csv             
├── 📂 Models  
│   ├── Reporte.cs           → Modelo para el reporte generado  
│   ├── TipoTransaccion.cs   → Enumerador para tipos de transacción  
│   └── Transaccion.cs       → Modelo de transacción base  
└── 📂 Interfaces  
│   ├── IReporteGenerador.cs → Contrato para generación de reportes  
│   └── ITransaccionLoader.cs → Contrato para carga de transacciones
│── Program.cs
```

## Documentación y Calidad del Código
El código sigue estos principios:
- **Documentación**: Interfaces y modelos bien documentados
- **Legibilidad**: 
  - Nombres descriptivos de clases, métodos y propiedades
  - Espaciado consistente
  - Métodos cortos con responsabilidad única
- **Mantenibilidad**:
  - Fácil de extender (ej: añadir nuevos cálculos al reporte)
  - Bajo acoplamiento entre componentes
