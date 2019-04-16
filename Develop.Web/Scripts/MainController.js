function additem() {
    var idxitem = $('#Count').val();
    idxitem++;
    $('#Count').val(idxitem);
    
    var Product = $('#ListProduct').clone();
    Product.find("#CatalogueID").attr("name", "items[" + idxitem + "].CatalogueID").attr("id", "CatalogueID[" + idxitem + "]").val('');
    Product.find("#qty").attr("name", "items[" + idxitem + "].Qty").attr("id", "qty[" + idxitem + "]").val('');
    Product.find("#price").attr("name", "items[" + idxitem + "].price").attr("id", "price[" + idxitem + "]").val('');
    Product.find("#Subtotal").attr("name", "total[" + idxitem + "]").attr("id", "Subtotal[" + idxitem + "]").val('');
    $('table#Items tbody').append(Product);
    
}

function changedata(id) {
    $('#price').val($("#CatalogueID").find(':selected').attr('data-price'));
    $('#qty').val(0);
}

$('table#Items tbody tr').on('mouseup keyup', 'input[type=number]', () => calculateTotals());

function calculateTotals() {
    const subtotals = $('#ListProduct').map((idx, val) => calculateSubtotal(val)).get();
    const total = subtotals.reduce((a, v) => a + Number(v), 0);
    $('#GrandTotal').text(formatAsCurrency(total));
}

function calc_total() {
    total = 0;
    $('#Subtotal').each(function () {
        total += parseInt($(this).val());
    });
    $('#GrandTotal').text(formatAsCurrency(total));
}

function calculateSubtotal(row) {
    const $row = $(row);
    const inputs = $row.find('input[type=number]');
    const subtotal = inputs[0].value * inputs[1].value;
    $row.find('.total').val(subtotal);
    calc_total();
    return subtotal;
}

function formatAsCurrency(amount) {
    if (amount != null && amount > 1) {
        return `Rp ${Number(amount).toFixed(2)}`;
    } else {
        return `Rp  0.00`;
    }
}
