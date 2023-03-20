function addToCart(id, name) {
    $.ajax({
        type: 'POST',
        url: '@Url.Action("AddToCart", "Home")',
        data: { id: id, name: name },
        success: function () {
            alert('Item added to cart!');
        },
        error: function () {
            alert('Error adding item to cart.');
        }
    });
}