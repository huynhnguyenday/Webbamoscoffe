$(document).ready(function () {
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();

        var id = $(this).data('id');
        var quantity = 1; // Mặc định quantity là 1 nếu không phải DetailView

        // Kiểm tra nếu đang ở trang DetailView thì lấy số lượng từ form
        if ($(this).closest('.product_details').length > 0) {
            quantity = parseInt($('#quantity_value').text().trim());
        }

        $.ajax({
            type: "POST",
            url: "/Cart/AddToCart",
            data: { id: id, quantity: quantity },
            success: function (response) {
                // Hiển thị thông báo hoặc cập nhật giỏ hàng tại đây
                $('#notificationContainer').html(response);
                $('#notificationContainer').show();
            },
            error: function () {
                alert("Có lỗi xảy ra. Vui lòng thử lại.");
            }
        });
    });
});
