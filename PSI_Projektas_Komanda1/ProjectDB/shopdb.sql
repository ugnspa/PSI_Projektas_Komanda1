-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 18, 2023 at 06:13 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `shopdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `airconditioners`
--

CREATE TABLE `airconditioners` (
  `pic` varchar(255) DEFAULT NULL,
  `id_AirConditioner` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) DEFAULT NULL,
  `max_area` decimal(18,3) DEFAULT NULL,
  `min_temp` int(11) DEFAULT NULL,
  `max_temp` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cameras`
--

CREATE TABLE `cameras` (
  `pic` varchar(255) DEFAULT NULL,
  `id_Camera` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) DEFAULT NULL,
  `megal_pixels` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `computers`
--

CREATE TABLE `computers` (
  `pic` varchar(255) DEFAULT NULL,
  `id_Computer` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) DEFAULT NULL,
  `processor` varchar(255) DEFAULT NULL,
  `motherboard` varchar(255) DEFAULT NULL,
  `gpu` varchar(255) DEFAULT NULL,
  `ram` int(11) DEFAULT NULL,
  `memory` int(11) DEFAULT NULL,
  `power_supply_wattage` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `computers`
--

INSERT INTO `computers` (`pic`, `id_Computer`, `brand`, `model`, `name`, `description`, `amount`, `price`, `processor`, `motherboard`, `gpu`, `ram`, `memory`, `power_supply_wattage`) VALUES
('https://www.bekredito.lt/wp-content/uploads/2022/08/lenovo-82jw00jbpb-legion-5-15ach-PG57330978BK.jpg16614606762097-400x400.jpg', 1, 'Lenovo', 'Legion', 'Lenovo Legion Y740', 'A high-end gaming laptop with a sleek design', 4, '2499.000', 'Intel Core i9', 'Intel Z390', 'NVIDIA GeForce RTX 2080 Max-Q', 32, 1000, 300),
('https://img.computerunivers.net/images/400x400/908930009EE7FD11CE044DEC89789248.jpg', 2, 'ASUS', 'ROG', 'ASUS ROG Strix G17', 'A powerful gaming laptop with an eye-catching design', 4, '1999.000', 'AMD Ryzen 9', 'AMD X570', 'NVIDIA GeForce RTX 3070', 32, 1000, 300),
('https://cdn.mall.adeptmind.ai/https%3A%2F%2Fmultimedia.bbycastatic.ca%2Fmultimedia%2Fproducts%2F500x500%2F163%2F16378%2F16378368_5.jpeg_medium.jpg', 3, 'MSI', 'GS', 'MSI GS75 Stealth', 'A slim gaming laptop with powerful hardware', 4, '2399.000', 'Intel Core i7', 'Intel HM370', 'NVIDIA GeForce RTX 2080 Max-Q', 32, 512, 250),
('https://multitech-lb.com/wp-content/uploads/multitech-lebanon-ACER-PREDATOR-HELIOS-300-PH315-55-70ZV-400x400.jpg', 4, 'Acer', 'Predator', 'Acer Predator Helios 300', 'A budget-friendly gaming laptop with solid performance', 4, '1199.000', 'Intel Core i7', 'Intel HM470', 'NVIDIA GeForce RTX 3060', 16, 512, 300),
('https://img.computerunivers.net/images/400x400/9085658730D6D54ECED743D08741D389.jpg', 5, 'Razer', 'Blade', 'Razer Blade Pro 17', 'A premium gaming laptop with top-of-the-line specs', 4, '3799.000', 'Intel Core i9', 'Intel HM470', 'NVIDIA GeForce RTX 3080', 32, 1000, 350),
('https://www.kilobaitas.lt//ImageHandler.ashx?ImageUrl=ItemImages%2FLocal%2FTdBaltic%2FTdBaltic_3ZV24EA-ABU_ProductPicture.jpg', 6, 'HP', 'Omen', 'HP Omen 15', 'A powerful gaming laptop with a minimalist design', 4, '1299.000', 'AMD Ryzen 7', 'AMD X570', 'NVIDIA GeForce RTX 3070', 16, 512, 300),
('https://img.computerunivers.net/images/400x400/908325176DACF9381ABB4EA3BC9259E1.jpg', 7, 'Lenovo', 'ThinkPad', 'Lenovo ThinkPad X1 Carbon', 'A business laptop with strong performance and security features', 4, '1449.000', 'Intel Core i7', 'Intel vPro', 'Intel UHD Graphics 620', 16, 512, 65),
('https://kainos-img.dgn.lt/photos2_25_62424323/asus-zenbook-ux425ja-hm254t-14-fhd-ips-i5-1035g1-8gb-512ssd-w10.jpg', 8, 'ASUS', 'ZenBook', 'ASUS ZenBook 14', 'An ultraportable laptop with a stunning display', 4, '1199.000', 'Intel Core i7', 'Intel HM470', 'NVIDIA GeForce MX450', 16, 512, 150),
('/css/pictures/dell.jpg', 9, 'Dell', 'XPS', 'Dell XPS 15', 'A high-end laptop with a stunning 4K display', 4, '2399.000', 'Intel Core i9', 'Intel HM470', 'NVIDIA GeForce GTX 1650 Ti', 32, 1000, 300),
('https://www.kilobaitas.lt//ImageHandler.ashx?ImageUrl=ItemImages%2FLocal%2FTdBaltic%2FTdBaltic_4L6M3EAABB_ProductPicture.jpg', 10, 'HP', 'Spectre', 'HP Spectre x360', 'A premium 2-in-1 laptop with a sleek design', 4, '1499.000', 'Intel Core i7', 'Intel HM470', 'Intel Iris Xe Graphics', 16, 512, 75),
('https://www.bekredito.lt/wp-content/uploads/2022/07/lenovo-ideapad-5-14are05-pilka-r5-VL-15392375-BK.jpg16582709568056-400x400.jpg', 11, 'Lenovo', 'IdeaPad', 'Lenovo IdeaPad 5', 'A mid-range laptop with solid specs', 4, '899.000', 'AMD Ryzen 7', 'AMD B550', 'NVIDIA GeForce MX450', 16, 512, 150),
('https://kainos-img.dgn.lt/photos2_25_57017815/asus-vivobook-s15-s533fa-bq009t-156-intel-i5-10210u-8gb-512gb-ssd-intel-uhd-windows-10-home.jpg', 12, 'ASUS', 'VivoBook', 'ASUS VivoBook S15', 'A budget-friendly laptop with a modern design', 4, '599.000', 'Intel Core i5', 'Intel HM470', 'Intel UHD Graphics 620', 8, 256, 75),
('https://images.kaina24.lt/9/71/dell-latitude-9510.jpg', 13, 'Dell', 'Latitude', 'Dell Latitude 9510', 'A business laptop with long battery life', 4, '1999.000', 'Intel Core i7', 'Intel vPro', 'Intel UHD Graphics', 16, 512, 75),
('https://cdn.cs.1worldsync.com/99/9d/999dc6a0-df08-4122-bb2c-99658722df2c.jpg', 14, 'HP', 'EliteBook', 'HP EliteBook 840 G8', 'A business laptop with a sturdy design', 4, '1199.000', 'Intel Core i5', 'Intel vPro', 'Intel UHD Graphics', 16, 512, 65),
('https://assets.grandandtoy.com/graphics/400x400/c20/21/20213EE7-FCFF-451C-908D-733835CAE7A8.jpg', 15, 'Lenovo', 'ThinkBook', 'Lenovo ThinkBook 13s', 'A business laptop with a modern design', 4, '899.000', 'Intel Core i5', 'Intel vPro', 'Intel UHD Graphics', 8, 256, 75),
('https://wecelltrade.com/wp-content/uploads/2023/01/Chromebook-Flip-C436.jpg', 16, 'ASUS', 'Chromebook', 'ASUS Chromebook Flip C434', 'A lightweight Chromebook with a premium look and feel', 4, '569.000', 'Intel Core m3', 'Intel Core m3', 'Intel HD Graphics 615', 4, 64, 65),
('https://www.discorpshop.com/autoimg/3225917/400x400/ffffff/5550.jpg', 17, 'Dell', 'Precision', 'Dell Precision 5550', 'A high-end mobile workstation for professionals', 4, '2199.000', 'Intel Core i7', 'Intel Xeon', 'NVIDIA Quadro T1000', 16, 512, 250),
('https://img.computerunivers.net/images/400x400/908437165E0D03798D664BAB83B692D2.jpg', 18, 'HP', 'ZBook', 'HP ZBook Studio G8', 'A mobile workstation for creatives and professionals', 4, '3499.000', 'Intel Core i7', 'Intel Xeon', 'NVIDIA GeForce RTX 3070', 32, 1000, 300),
('https://aitnetas.lt/144296-medium_default/lenovo-thinkpad-x1-carbon-gen-10-black-paint-14-ips-wquxga-1920-x-1200-anti-glare-i7-1260p-16-gb-ssd-512-gb-intel-iris-xe-graphi.jpg', 19, 'Lenovo', 'ThinkPad', 'Lenovo ThinkPad X1 Carbon', 'A premium business laptop with a durable design', 4, '1599.000', 'Intel Core i7', 'Intel vPro', 'Intel UHD Graphics', 16, 1000, 75),
('https://cdn.shopify.com/s/files/1/0228/7629/1136/products/04_15_Scar_L_400x.png?v=1643823634', 20, 'ASUS', 'ROG Strix', 'ASUS ROG Strix Scar 15', 'A high-end gaming laptop with a fast display', 4, '2999.000', 'Intel Core i9', 'Intel HM470', 'NVIDIA GeForce RTX 3080', 32, 1000, 350),
('https://images.manokaina.lt/gHuuzm8zVhX3RCfJMAekotZ9PvY=/400x400/middle/https://www.skytech.lt/images/medium/8/2915808.png', 21, 'Dell', 'G Series', 'Dell G5 15 SE', 'A mid-range gaming laptop with an AMD CPU', 4, '999.000', 'AMD Ryzen 7', 'AMD B550', 'AMD Radeon RX 5600M', 16, 512, 200),
('https://www.kilobaitas.lt//ImageHandler.ashx?ImageUrl=ItemImages%2FLocal%2FTdBaltic%2FTdBaltic_3ZV24EA-ABU_ProductPicture.jpg', 22, 'HP', 'Omen', 'HP Omen 15', 'A mid-range gaming laptop with a fast display', 4, '1199.000', 'Intel Core i7', 'Intel HM470', 'NVIDIA GeForce RTX 2060', 16, 512, 250),
('https://www.bekredito.lt/wp-content/uploads/2022/08/lenovo-82jw00jbpb-legion-5-15ach-PG57330978BK.jpg16614606762097-400x400.jpg', 23, 'Lenovo', 'Legion', 'Lenovo Legion 5', 'A mid-range gaming laptop with a long battery life', 4, '1099.000', 'AMD Ryzen 7', 'AMD B550', 'NVIDIA GeForce GTX 1660 Ti', 16, 512, 200),
('https://www.discorpshop.com/autoimg/3014215/400x400/ffffff/fx506ih-hn190t-be.jpg', 24, 'ASUS', 'TUF Gaming', 'ASUS TUF Gaming A15', 'A budget-friendly gaming laptop with a sturdy design', 4, '799.000', 'AMD Ryzen 5', 'AMD B550', 'NVIDIA GeForce GTX 1650', 8, 512, 200),
('https://img.computerunivers.net/images/400x400/908554789B1610355E9D40169247686A.jpg', 25, 'Dell', 'Alienware', 'Dell Alienware m15 R6', 'A high-end gaming laptop with a premium design', 4, '2799.000', 'Intel Core i9', 'Intel HM470', 'NVIDIA GeForce RTX 3080', 32, 1000, 250),
('https://aitnetas.lt/144296-medium_default/lenovo-thinkpad-x1-carbon-gen-10-black-paint-14-ips-wquxga-1920-x-1200-anti-glare-i7-1260p-16-gb-ssd-512-gb-intel-iris-xe-graphi.jpg', 26, 'Lenovo', 'ThinkPad', 'Lenovo ThinkPad X1 Carbon', 'A premium ultrabook for business users', 5, '1600.000', 'Intel Core i7', 'Intel UHD Graphics', 'Integrated', 16, 512, 65),
('https://multimedia.bbycastatic.ca/multimedia/products/400x400/162/16271/16271527.jpg', 27, 'Asus', 'ROG', 'Asus ROG Zephyrus G15', 'A high-end gaming laptop with great performance', 4, '2000.000', 'AMD Ryzen 9', 'NVIDIA GeForce RTX 3080', 'AMD Radeon Graphics', 32, 1, 250),
('https://static3.webx.pk/files/21500/Images/Thumbnails-Large/er0002-21500-722395-131221101044819.jpg', 28, 'HP', 'Pavilion', 'HP Pavilion x360', 'A versatile 2-in-1 laptop with a touchscreen display', 4, '800.000', 'Intel Core i5', 'Intel UHD Graphics', 'Integrated', 8, 256, 75),
('https://img.computerunivers.net/images/400x400/90905238FC36E9663E844B51B02A44F4.jpg', 29, 'Acer', 'Nitro', 'Acer Nitro 5', 'An affordable gaming laptop with decent specs', 4, '700.000', 'AMD Ryzen 5', 'NVIDIA GeForce GTX 1650', 'Integrated', 8, 512, 200),
('https://img.computerunivers.net/images/400x400/90906784A4F2CFE48B974144B8D7DE1D.jpg', 30, 'Dell', 'XPS', 'Dell XPS 13', 'A premium ultrabook with excellent build quality', 4, '1500.000', 'Intel Core i7', 'Intel UHD Graphics', 'Integrated', 16, 512, 65),
('https://www.kilobaitas.lt//ImageHandler.ashx?ImageUrl=ItemImages%2FLocal%2FTdBaltic%2FTdBaltic_4L6M3EAABB_ProductPicture.jpg', 31, 'HP', 'Spectre', 'HP Spectre x360', 'A stylish 2-in-1 laptop with a 4K display', 4, '1800.000', 'Intel Core i7', 'Intel Iris Plus Graphics', 'Integrated', 16, 512, 65),
('https://mrlaptop.pk/wp-content/uploads/2020/10/6367799ld-1540-9360-280220014011.jpg', 32, 'Lenovo', 'Yoga', 'Lenovo Yoga C940', 'A high-end 2-in-1 laptop with great performance', 4, '1700.000', 'Intel Core i7', 'Intel Iris Plus Graphics', 'Integrated', 16, 512, 65),
('https://kainos-img.dgn.lt/photos2_25_62424323/asus-zenbook-ux425ja-hm254t-14-fhd-ips-i5-1035g1-8gb-512ssd-w10.jpg', 33, 'Asus', 'ZenBook', 'Asus ZenBook 14', 'A sleek ultrabook with a 14-inch display', 4, '1200.000', 'Intel Core i7', 'Intel Iris Plus Graphics', 'Integrated', 16, 512, 75),
('https://www.kilobaitas.lt//ImageHandler.ashx?ImageUrl=ItemImages%2FLocal%2FTdBaltic%2FTdBaltic_5EN50EAUUW_ProductPicture.jpg', 34, 'HP', 'Envy', 'HP Envy 13', 'A premium ultrabook with a long battery life', 4, '1300.000', 'Intel Core i7', 'Intel Iris Plus Graphics', 'Integrated', 16, 512, 65);

-- --------------------------------------------------------

--
-- Table structure for table `dishwashers`
--

CREATE TABLE `dishwashers` (
  `pic` varchar(255) DEFAULT NULL,
  `id_Dishwasher` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) NOT NULL,
  `volume` decimal(18,3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `dryers`
--

CREATE TABLE `dryers` (
  `pic` varchar(255) DEFAULT NULL,
  `id_Dryer` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) NOT NULL,
  `volume` decimal(18,3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `fridges`
--

CREATE TABLE `fridges` (
  `pic` varchar(255) DEFAULT NULL,
  `id_Fridge` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) NOT NULL,
  `freezer` tinyint(1) DEFAULT NULL,
  `volume` decimal(18,3) DEFAULT NULL,
  `freezer_volume` decimal(18,3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `heatingsystems`
--

CREATE TABLE `heatingsystems` (
  `pic` varchar(255) DEFAULT NULL,
  `id_HeatingSystem` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) NOT NULL,
  `max_area` decimal(18,3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `microwaves`
--

CREATE TABLE `microwaves` (
  `pic` varchar(255) DEFAULT NULL,
  `id_Microwave` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) NOT NULL,
  `volume` decimal(18,3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ovens`
--

CREATE TABLE `ovens` (
  `pic` varchar(255) DEFAULT NULL,
  `id_Oven` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) NOT NULL,
  `volume` decimal(18,3) DEFAULT NULL,
  `type` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `smartphones`
--

CREATE TABLE `smartphones` (
  `pic` varchar(255) DEFAULT NULL,
  `id_Smartphone` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) NOT NULL,
  `processor` varchar(255) DEFAULT NULL,
  `ram` int(11) DEFAULT NULL,
  `gpu` varchar(255) DEFAULT NULL,
  `memory` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `smartphones`
--

INSERT INTO `smartphones` (`pic`, `id_Smartphone`, `brand`, `model`, `name`, `description`, `amount`, `price`, `processor`, `ram`, `gpu`, `memory`) VALUES
('/css/pictures/iphone.jpg', 1, 'Apple', 'iPhone', 'Apple iPhone 13', 'The iPhone 13 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle.', 100, '699.000', 'Hexa-core', 4, 'A15 Bionic', 128);

-- --------------------------------------------------------

--
-- Table structure for table `stoves`
--

CREATE TABLE `stoves` (
  `pic` varchar(255) DEFAULT NULL,
  `id_Stove` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) NOT NULL,
  `count` int(11) DEFAULT NULL,
  `electric` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tvs`
--

CREATE TABLE `tvs` (
  `pic` varchar(255) DEFAULT NULL,
  `id_TV` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) NOT NULL,
  `diagonal` decimal(18,3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `vacuums`
--

CREATE TABLE `vacuums` (
  `pic` varchar(255) DEFAULT NULL,
  `id_Vacuum` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) NOT NULL,
  `volume` decimal(18,3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `washingmachines`
--

CREATE TABLE `washingmachines` (
  `pic` varchar(255) DEFAULT NULL,
  `id_WashingMachine` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) NOT NULL,
  `volume` decimal(18,3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `watches`
--

CREATE TABLE `watches` (
  `pic` varchar(255) DEFAULT NULL,
  `id_Watch` int(11) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `name` varchar(70) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(18,3) NOT NULL,
  `smart` tinyint(1) DEFAULT NULL,
  `days_charged` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `airconditioners`
--
ALTER TABLE `airconditioners`
  ADD PRIMARY KEY (`id_AirConditioner`);

--
-- Indexes for table `cameras`
--
ALTER TABLE `cameras`
  ADD PRIMARY KEY (`id_Camera`);

--
-- Indexes for table `computers`
--
ALTER TABLE `computers`
  ADD PRIMARY KEY (`id_Computer`);

--
-- Indexes for table `dishwashers`
--
ALTER TABLE `dishwashers`
  ADD PRIMARY KEY (`id_Dishwasher`);

--
-- Indexes for table `dryers`
--
ALTER TABLE `dryers`
  ADD PRIMARY KEY (`id_Dryer`);

--
-- Indexes for table `fridges`
--
ALTER TABLE `fridges`
  ADD PRIMARY KEY (`id_Fridge`);

--
-- Indexes for table `heatingsystems`
--
ALTER TABLE `heatingsystems`
  ADD PRIMARY KEY (`id_HeatingSystem`);

--
-- Indexes for table `microwaves`
--
ALTER TABLE `microwaves`
  ADD PRIMARY KEY (`id_Microwave`);

--
-- Indexes for table `ovens`
--
ALTER TABLE `ovens`
  ADD PRIMARY KEY (`id_Oven`);

--
-- Indexes for table `smartphones`
--
ALTER TABLE `smartphones`
  ADD PRIMARY KEY (`id_Smartphone`);

--
-- Indexes for table `stoves`
--
ALTER TABLE `stoves`
  ADD PRIMARY KEY (`id_Stove`);

--
-- Indexes for table `tvs`
--
ALTER TABLE `tvs`
  ADD PRIMARY KEY (`id_TV`);

--
-- Indexes for table `vacuums`
--
ALTER TABLE `vacuums`
  ADD PRIMARY KEY (`id_Vacuum`);

--
-- Indexes for table `washingmachines`
--
ALTER TABLE `washingmachines`
  ADD PRIMARY KEY (`id_WashingMachine`);

--
-- Indexes for table `watches`
--
ALTER TABLE `watches`
  ADD PRIMARY KEY (`id_Watch`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
