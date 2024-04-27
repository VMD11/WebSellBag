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
		});

		function convertVND(amount) {
			return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(amount);
		}
	});

	
	/* ..............................................
	   Fix product name
	   ................................................. */
	$(document).ready(function () {
		$('.product-name').each(function () {
			var maxLength = 32; // Độ dài tối đa của tên sản phẩm
			var text = $(this).text();

			if (text.length > maxLength) {
				var trimmedText = text.substring(0, maxLength - 3) + '...';
				$(this).text(trimmedText);
			}
		});
	});

	$(document).ready(function () {
		//$('#loginForm').submit(function (e) {
		//	e.preventDefault();

		//	$.ajax({
		//		url: '@Url.Action("Login","Account")',
		//		type: 'POST',
		//		data: $(this).serialize(),
		//		success: function (response) {
		//			location.reload();
					
		//		},
		//		error: function () {
		//			alert('Đăng nhập thất bại. Vui lòng thử lại!');
		//		}
		//	});
		//});
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
			//$('#newaddress').addClass('show');
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

