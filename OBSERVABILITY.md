# Transporter Observability Stack

This docker-compose setup provides a complete observability stack for the Transporter Web application using OpenTelemetry, Prometheus, Tempo, and Grafana.

## Components

- **Transporter Web**: Your ASP.NET Core application
- **OpenTelemetry Collector**: Collects traces and metrics from your application
- **Prometheus**: Stores metrics data
- **Tempo**: Stores distributed tracing data
- **Grafana**: Visualizes metrics and traces

## Getting Started

1. **Build and start all services:**
   ```bash
   docker-compose up -d
   ```

2. **Access the services:**
   - **Transporter Web**: http://localhost:8080
   - **Grafana**: http://localhost:3000 (admin/admin)
   - **Prometheus**: http://localhost:9090
   - **OpenTelemetry Collector**: http://localhost:8888/metrics

## Configuration

The setup automatically configures your application to send telemetry data by setting these environment variables:

- `OpenTelemetry__Tracing__OtlpExporter__Enabled=true`
- `OpenTelemetry__Tracing__OtlpExporter__Endpoint=http://otel-collector:4317`
- `OpenTelemetry__Metrics__OtlpExporter__Enabled=true`
- `OpenTelemetry__Metrics__OtlpExporter__Endpoint=http://otel-collector:4317`

## Grafana Dashboards

The setup includes:
- Pre-configured Prometheus and Tempo datasources
- A basic ASP.NET Core dashboard showing HTTP request metrics
- Dashboard location: `/grafana/dashboards/`

## Viewing Data

1. **Metrics**: Go to Grafana → Dashboards → "Transporter Web Dashboard"
2. **Traces**: Go to Grafana → Explore → Select "Tempo" datasource
3. **Raw Prometheus data**: Visit http://localhost:9090

## Stopping the Stack

```bash
docker-compose down
```

To also remove volumes (data will be lost):
```bash
docker-compose down -v
```

## Customization

- Modify `otel-collector-config.yaml` to change telemetry processing
- Edit `prometheus.yml` to add more scrape targets
- Add custom dashboards to `grafana/dashboards/`
- Adjust `tempo.yaml` for trace storage settings