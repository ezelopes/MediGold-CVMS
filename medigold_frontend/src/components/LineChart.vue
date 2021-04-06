<script>
import { Line } from "vue-chartjs";

export default {
  extends: Line,
  props: {
    label: {
      type: String
    },
    chartData: {
      type: Array
    },
    options: {
      type: Object
    },
    chartColors: {
      type: Object
    }
  },

  // eslint-disable-next-line @typescript-eslint/explicit-module-boundary-types
  mounted() {
    const dates = this.chartData.map(data => data.Date);
    const totals = this.chartData.map(data => data.Total);
    console.log(dates)
    console.log(dates)


    const {
      borderColor,
      pointBorderColor,
      pointBackgroundColor,
      backgroundColor
    } = this.chartColors;

    this.renderChart(
      {
        labels: dates,
        datasets: [
          {
            label: this.label,
            data: totals,
            borderColor: borderColor,
            pointBorderColor: pointBorderColor,
            pointBackgroundColor: pointBackgroundColor,
            backgroundColor: backgroundColor
          }
        ]
      },
      this.options
    );
  }
};
</script>
