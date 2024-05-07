﻿(function ($) {
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
		$('.minus').on('click', function () {
			var input = $('#quantityInput');
			var currentValue = parseInt(input.val());
			if (currentValue > 1) {
				input.val(currentValue - 1);
			}
		});
		$('.plus').on('click', function () {
			var input = $('#quantityInput');
			var currentValue = parseInt(input.val());
			input.val(currentValue + 1);

		});
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
	$(document).ready(function () {
		function resize() {
			var windowWidth = $(window).width();

			var maxLength;
			if (windowWidth > 1200) {
				maxLength = 32; 
			} else {
				maxLength = 24; 
			}
			$('.product-name').each(function () {
				var text = $(this).text();

				if (text.length > maxLength) {
					var trimmedText = text.substring(0, maxLength - 3) + '...';
					$(this).text(trimmedText);
				}
			});
		};
		$(window).resize(function () {
			resize();
		});
	});

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

				},
				error: function () {
					alert('Đăng nhập thất bại. Vui lòng thử lại!');
					location.reload();
				}
			});
		});



	});

	$(document).ready(function () {
		$('#orderForm').on('submit', function (e) {
			e.preventDefault();
			var ID_Address = $('input[name="ID_Address"]:checked').val() || "";
			//if (ID_Address === undefined) {
			//	ID_Address = "";
			//}
			var LastName = $('#lastName').val();
			var FirstName = $('#firstName').val();
			var UserName = $('#username').val();
			var City = $('#city').val();
			var District = $('#district').val();
			var Ward = $('#ward').val();
			var SpecificAddress = $('#specificaddress').val();
			var ShippingName = $('input[name="ShippingName"]:checked').val();
			var PaymentName = $('input[name="PaymentName"]:checked').val();
			var TotalMoney = $('#totalmoney').val();
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
						window.location.href = '/Order/Index';
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

//document.addEventListener('DOMContentLoaded', function () {
//	var addButton = document.getElementById('addButton');
//	addButton.addEventListener('click', function (e) {
//		e.preventDefault();
//		var id_product = addButton.getAttribute('data-id');
//		var quantity = addButton.getAttribute('data-quantity');

//		var xhr = new XMLHttpRequest();

//		xhr.open('POST', addButton.getAttribute('href'), true);
//		xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
//		xhr.onload = function () {
//			if (xhr.status >= 200 && xhr.status < 300) {

//				location.reload();
//			} else {
//				console.log('Đã xảy ra lỗi khi gửi yêu cầu.');
//			}
//		};
//		xhr.onerror = function () {
//			console.log('Đã xảy ra lỗi khi gửi yêu cầu.');
//		};
//		xhr.send('ID_Product=' + id_product + '&Quantity=' + quantity);
//	});
//});



