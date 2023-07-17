function ResizeChart(chartId) {
    const chart = $('#' + chartId).data('kendoChart');
    console.log(chart);
    chart.resize();
}