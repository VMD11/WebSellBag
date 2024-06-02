(function ($) {
    "use strict";
	
	/* ..............................................
	   Loader 
	   ................................................. */
	$(window).on('load', function() {
		$('.preloader').fadeOut();
		$('#preloader').delay(550).fadeOut('slow');
		$('body').delay(450).css({
			'overflow': 'visible'
		});
	});

	/* ..............................................
	   Fixed Menu
	   ................................................. */

	$(window).on('scroll', function() {
		if ($(window).scrollTop() > 50) {
			$('.main-header').addClass('fixed-menu');
		} else {
			$('.main-header').removeClass('fixed-menu');
		}
	});

	/* ..............................................
	   Gallery
	   ................................................. */

	$('#slides-shop').superslides({
		inherit_width_from: '.cover-slides',
		inherit_height_from: '.cover-slides',
		play: 5000,
		animation: 'fade',
	});

	$(".cover-slides ul li").append("<div class='overlay-background'></div>");

	/* ..............................................
	   Map Full
	   ................................................. */

	$(document).ready(function() {
		$(window).on('scroll', function() {
			if ($(this).scrollTop() > 100) {
				$('#back-to-top').fadeIn();
			} else {
				$('#back-to-top').fadeOut();
			}
		});
		$('#back-to-top').click(function() {
			$("html, body").animate({
				scrollTop: 0
			}, 600);
			return false;
		});
	});

	/* ..............................................
	   Special Menu
	   ................................................. */

	var Container = $('.container');
	Container.imagesLoaded(function() {
		var portfolio = $('.special-menu');
		portfolio.on('click', 'button', function() {
			$(this).addClass('active').siblings().removeClass('active');
			var filterValue = $(this).attr('data-filter');
			$grid.isotope({
				filter: filterValue
			});
		});
		var $grid = $('.special-list').isotope({
			itemSelector: '.special-grid'
		});
	});

	/* ..............................................
	   BaguetteBox
	   ................................................. */

	baguetteBox.run('.tz-gallery', {
		animation: 'fadeIn',
		noScrollbars: true
	});

	/* ..............................................
	   Offer Box
	   ................................................. */

	$('.offer-box').inewsticker({
		speed: 3000,
		effect: 'fade',
		dir: 'ltr',
		font_size: 13,
		color: '#ffffff',
		font_family: 'Montserrat, sans-serif',
		delay_after: 1000
	});

	/* ..............................................
	   Tooltip
	   ................................................. */

	$(document).ready(function() {
		$('[data-toggle="tooltip"]').tooltip();
	});

	/* ..............................................
	   Owl Carousel Instagram Feed
	   ................................................. */

	$('.main-instagram').owlCarousel({
		loop: true,
		margin: 0,
		dots: false,
		autoplay: true,
		autoplayTimeout: 3000,
		autoplayHoverPause: true,
		navText: ["<i class='fas fa-arrow-left'></i>", "<i class='fas fa-arrow-right'></i>"],
		responsive: {
			0: {
				items: 2,
				nav: true
			},
			600: {
				items: 4,
				nav: true
			},
			1000: {
				items: 8,
				nav: true,
				loop: true
			}
		}
	});

	/* ..............................................
	   Featured Products
	   ................................................. */

	$('.featured-products-box').owlCarousel({
		loop: true,
		margin: 0,
		dots: false,
		autoplay: true,
		autoplayTimeout: 3000,
		autoplayHoverPause: true,
		navText: ["<i class='fas fa-arrow-left'></i>", "<i class='fas fa-arrow-right'></i>"],
		responsive: {
			0: {
				items: 1,
				nav: true
			},
			600: {
				items: 3,
				nav: true
			},
			1000: {
				items: 4,
				nav: true,
				loop: true
			}
		}
	});

	/* ..............................................
	   Scroll
	   ................................................. */

	$(document).ready(function() {
		$(window).on('scroll', function() {
			if ($(this).scrollTop() > 100) {
				$('#back-to-top').fadeIn();
			} else {
				$('#back-to-top').fadeOut();
			}
		});
		$('#back-to-top').click(function() {
			$("html, body").animate({
				scrollTop: 0
			}, 600);
			return false;
		});
	});


	/* ..............................................
	   Slider Range
	   ................................................. */

	$(function() {
		$("#slider-range").slider({
			range: true,
			min: 0,
			max: 4000,
			values: [1000, 3000],
			slide: function(event, ui) {
				$("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
			}
		});
		$("#amount").val("$" + $("#slider-range").slider("values", 0) +
			" - $" + $("#slider-range").slider("values", 1));
	});

	/* ..............................................
	   NiceScroll
	   ................................................. */
	$(".brand-box").niceScroll({
		cursorcolor: "#9b9b9c",
	});

	/* ..............................................
	   Update quantityInput
	   ................................................. */
	$(document).ready(function () {
		$('.minuss').on('click', function () {
			var input = $(this).siblings('.input-number').find('.quantity');
			var currentValue = parseInt(input.val());
			if (currentValue > 1) {
				input.val(currentValue - 1);
			}
		});
		$('.pluss').on('click', function () {
			var input = $(this).siblings('.input-number').find('.quantity');
			var quantity = parseInt($(this).data('quantity'));
			var currentValue = parseInt(input.val());
			console.log(currentValue + '/' + quantity);
			if (quantity == currentValue) {
				alert("Số lượng sản phẩm này chỉ còn " + quantity);
			} else {
				input.val(currentValue + 1);
			}

		});
		$('.minus').on('click', function () {
			var id = $(this).data('id');
			var input = $(this).siblings('.input-number').find('.quantity');
			var currentValue = parseInt(input.val());
			if (currentValue > 1) {
				input.val(currentValue - 1);
				updateCart(id, input.val());
			}
		});
		$('.plus').on('click', function () {
			var id = $(this).data('id');
			var input = $(this).siblings('.input-number').find('.quantity');
			var quantity = parseInt($(this).data('quantity'));
			var currentValue = parseInt(input.val());
			console.log(currentValue + '/' + quantity);
			if (quantity == currentValue) {
				alert('Số lượng sản phẩm này chỉ còn ' + quantity);
			} else {
				input.val(currentValue + 1);
				updateCart(id, input.val());
			}

		});

		function updateCart(id, quantity) {
			$.ajax({
				url: '/Cart/Update',
				type: 'POST',
				data: {
					ID_Product: id,
					Quantity: quantity
				},
				success: function (response) {
					if (response.result) {
						$('#TotalQuantity').text(response.TotalQuantity);
						$('#TotalMoney').text(convertVND(response.TotalMoney));
						$('#GrandTotal').text(convertVND(response.TotalMoney));
						$('#countCart').text(response.TotalQuantity);
					}
				},
				error: function () {
					alert('Có lỗi xảy ra khi cập nhật giỏ hàng.');
				}
			});
		}
		function convertVND(amount) {
			return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(amount);
		}
	});

	
	/* ..............................................
	   Update Shipping Cost
	   ................................................. */
	$(document).ready(function () {
		// Xử lý sự kiện khi click vào các radio button
		$('input[name="ShippingName"]').on('change', function () {
			// Lấy phí vận chuyển từ thuộc tính data của radio button đã chọn
			var shippingCost = $(this).data('shipping-cost');
			var totalMoney = $(this).data('total-money');
			var result = parseInt(shippingCost) + parseInt(totalMoney);
			// Hiển thị phí vận chuyển tương ứng
			$('#shippingCost').text(convertVND(shippingCost));
			$('#totalMoney').text(convertVND(result));
            $('#TotalMoney').val(result);
		});

		function convertVND(amount) {
			return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(amount);
		}
	});

	
	/* ..............................................
	   Fix product name
	   ................................................. */

	/* ..............................................
	   Form Checkout
	   ................................................. */
	$(document).ready(function () {
		$('#loginForm').on('submit', function (e) {
			e.preventDefault();
			$.ajax({
				url: $(this).attr('action'),
				type: 'POST',
				data: $(this).serialize(),
				success: function (response) {
					location.reload();
					//if (response.result) {
					//} else {
					//	alert('Thông tin tài khoản hoặc mật khẩu không chính xác');
					//}

				},
				error: function () {
					alert('Đăng nhập thất bại. Vui lòng thử lại!');
					location.reload();
				}
			});
		});



	});

	/* ..............................................
	   Form Order
	   ................................................. */
	$(document).ready(function () {
		$('#orderForm').on('submit', function (e) {
			e.preventDefault();
			var ID_Address = $('input[name="ID_Address"]:checked').val() || "";
			var LastName = $('#lastName').val();
			var FirstName = $('#firstName').val();
			var UserName = $('#username').val();
			var City = $('#city').val();
			var District = $('#district').val();
			var Ward = $('#ward').val();
			var SpecificAddress = $('#specificaddress').val();
			var PaymentName = $('input[name="PaymentName"]:checked').val();
			var Shipping = $('input[name="ShippingName"]:checked');
			var ShippingName = Shipping.val();
			var Money = parseInt(Shipping.attr('data-total-money'));
			var Cost = parseInt(Shipping.attr('data-shipping-cost'));
			var TotalMoney = Money + Cost;
			console.log(ShippingName + TotalMoney);
			var formData = new FormData();
			formData.append("ID_Address", ID_Address);
			formData.append("LastName", LastName);
			formData.append("FirstName", FirstName);
			formData.append("UserName", UserName);
			formData.append("City", City);
			formData.append("District", District);
			formData.append("Ward", Ward);
			formData.append("SpecificAddress", SpecificAddress);
			formData.append("ShippingName", ShippingName);
			formData.append("PaymentName", PaymentName);
			formData.append("TotalMoney", TotalMoney);
			$.ajax({
				url: $(this).attr('action'),
				type: 'POST',
				data: formData,
				processData: false,
				contentType: false,
				dataType:'json',
				success: function (response) {
					if (response.result) {
						window.location.href = response.redirectUrl;
					} else {
						alert('Đặt hàng thất bại. Vui lòng thử lại!');
						location.reload();
					}
				},
				error: function () {
					alert('Đặt hàng thất bại. Vui lòng thử lại!');
					location.reload();
				}
			});
		});

	});

	$(document).ready(function () {
		$('#submitInfoAddress').click(function () {
			$('#formInfo').removeClass('show');
			$('#shippingBox').removeClass('frozen');
			$('#order').addClass('show');
			$('#placeOrder').removeClass('d-none');
		});
		$('#addInfo').click(function () {
			$('#address').removeClass('show');
		});
	});


	$(document).ready(function () {
		$('.deleteBtn').on('click', function (e) {
			e.preventDefault();
			var id = $(this).attr('data-id');
			var url = $(this).attr('href');
			$('#delConfirmPopup').modal('show');
			console.log(url + id);
			$('#confirmDelBtn').off('click').on('click', function () {
				$.ajax({
					url: url,
					type: 'POST',
					data: { ID_Address: id },
					dataType: 'json',
					success: function (response) {
						if (response.result) {
							alert(response.message);
							location.reload();
							console.log('id: ' + id);
						} else {
							alert(response.message);
						}
					},
					error: function () {
						alert('Có lỗi xảy ra khi xóa');
					}
				});

				$('#delConfirmPopup').modal('hide');
			});
		});
	});
}(jQuery));


/* ..............................................
	Show Error
	................................................. */
document.addEventListener("DOMContentLoaded", function () {
	var errorDiv = document.querySelector(".error");
	if (errorDiv && "@ViewBag.Error_Text" !== null && "@ViewBag.Error_Text" !== undefined) {
		if ("@ViewBag.Error_Text".trim() !== "") {
			errorDiv.style.display = "block";
		}
	}
});


/* ..............................................
	Show Success
	................................................. */
document.addEventListener("DOMContentLoaded", function () {
	var successDiv = document.querySelector(".success");
	if (successDiv && "@ViewBag.Success_Text" !== null && "@ViewBag.Success_Text" !== undefined) {
		if ("@ViewBag.Success_Text".trim() !== "") {
			successDiv.style.display = "block";
		}
	}
});

/* ..............................................
	Show Password
	................................................. */
function showPass() {
	var passwordInput = document.getElementById("passwordInput");
	var eyeIcon = document.getElementById("eyeIcon");

	if (passwordInput.type === "password") {
		passwordInput.type = "text";
		eyeIcon.classList.remove("fa-eye-slash");
		eyeIcon.classList.add("fa-eye");
	} else {
		passwordInput.type = "password";
		eyeIcon.classList.remove("fa-eye");
		eyeIcon.classList.add("fa-eye-slash");
	}
}

document.addEventListener('DOMContentLoaded', function () {
	function resize() {
		var windowWidth = window.innerWidth;

		var maxLength;
		if (windowWidth >= 1200) {
			maxLength = 32;
		} else {
			maxLength = 24;
		}
		var productNames = document.querySelectorAll('.product-name');
		productNames.forEach(function (productName) {
			var text = productName.textContent;

			if (text.length > maxLength) {
				var trimmedText = text.substring(0, maxLength - 3) + '...';
				productName.textContent = trimmedText;
			}
		});
	};

	window.addEventListener('resize', function () {
		resize();
	});

	resize();
});




/* ..............................................
	Add Cart
	................................................. */
document.addEventListener('DOMContentLoaded', function () {
	var cartButtons = document.querySelectorAll('.cart');
	cartButtons.forEach(function (btn) {
		btn.addEventListener('click', function (e) {
			e.preventDefault();
			var id_product = btn.getAttribute('data-id');
			var quantity = btn.getAttribute('data-quantity');

			var xhr = new XMLHttpRequest();
			xhr.open('POST', btn.getAttribute('href'), true);
			xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
			xhr.onload = function () {
				if (xhr.status >= 200 && xhr.status < 300) {
					var response = JSON.parse(xhr.responseText);
					if (response.result) {
						alert('Thêm thành công');
						location.reload();
					}
					else {
						alert(response.message);
					}
				} else {
					alert('Đã xảy ra lỗi khi gửi yêu cầu.');
				}
			};
			xhr.onerror = function () {
				alert('Đã xảy ra lỗi khi gửi yêu cầu.');
			};
			xhr.send('ID_Product=' + id_product + '&Quantity=' + parseInt(quantity));
		});
	});
});

document.addEventListener('DOMContentLoaded', function () {
	var updateBtn = document.querySelectorAll('.updateBtn');
	var view = document.getElementById('update-address-view');
	updateBtn.forEach(function (btn) {
		btn.addEventListener('click', function (e) {
			e.preventDefault();
			var id_address = btn.getAttribute('data-id');
			console.log(id_address);
			var xhr = new XMLHttpRequest();
			xhr.open('GET', btn.getAttribute('href') + '?ID_Address=' + id_address, true); 
			xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
			xhr.onload = function () {
				if (xhr.status >= 200 && xhr.status < 300) {
					var response = JSON.parse(xhr.responseText);
					view.classList.remove('d-none'); 
					var closeBtn = document.getElementById('closeBtn');
					closeBtn.addEventListener('click', function () {
						view.classList.add('d-none');
					});
				} else {
					alert('Đã xảy ra lỗi khi gửi yêu cầu.');
				}
			};
			xhr.onerror = function () {
				alert('Đã xảy ra lỗi khi gửi yêu cầu.');
			};
			xhr.send(); 
		});
	});
	
});

document.addEventListener('DOMContentLoaded', function () {
	var cancelOrder = document.querySelectorAll('.cancelOrder');
	cancelOrder.forEach(function (btn) {
		btn.addEventListener('click', function () {
			var id = this.getAttribute('data-id');
			var url = '/Order/CancelOrder';
			console.log(id);
			$('#cancelConfirmPopup').modal('show');

			var confirmButton = document.getElementById('confirmCancelBtn');
			var newConfirmButton = confirmButton.cloneNode(true);
			confirmButton.parentNode.replaceChild(newConfirmButton, confirmButton);

			newConfirmButton.addEventListener('click', function () {
				var xhr = new XMLHttpRequest();
				xhr.open('POST', url, true);
				xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
				xhr.onload = function () {
					if (xhr.status >= 200 && xhr.status < 300) {
						var response = JSON.parse(xhr.responseText);
						alert(response.message + response.url);
						if (response.result) {
							location.reload();
							//location.href = response.url;
						}
					}
				};
				xhr.onerror = function () {
					alert('Đã xảy ra lỗi khi gửi yêu cầu.');
				};
				xhr.send('ID_Order=' + encodeURIComponent(id));
				console.log(xhr.responseURL);
				$('#cancelConfirmPopup').modal('hide');
			});
		});
	});
});