# ParkingSystem

ParkingSystem adalah aplikasi konsol sederhana untuk mengelola tempat parkir. Aplikasi ini memungkinkan Anda untuk membuat tempat parkir, memarkir kendaraan, mengosongkan slot parkir, dan melihat status parkir.

## Fitur

- Membuat tempat parkir dengan sejumlah slot tertentu.
- Memarkir kendaraan.
- Mengosongkan slot parkir.
- Menampilkan status tempat parkir.
- Menghitung jumlah kendaraan berdasarkan jenis.
- Menampilkan nomor registrasi kendaraan berdasarkan nomor plat ganjil/genap.
- Menampilkan nomor registrasi kendaraan berdasarkan warna.
- Menampilkan nomor slot berdasarkan warna kendaraan.
- Menampilkan nomor slot berdasarkan nomor registrasi kendaraan.

## Cara Menggunakan

1. Clone repositori ini ke komputer Anda.
2. Buka proyek di Visual Studio atau editor C# lainnya.
3. Jalankan aplikasi dengan cara buka terminal, lalu ketik dotnet run (sebelum menjalankan program ini, perhatikan terlebih dahulu alamat diraktori nya, pastikan semua file untuk menjalankan program ini tersedia)

### Perintah yang Tersedia

- `create_parking_lot <size>`: Membuat tempat parkir dengan sejumlah slot tertentu. 

   Contoh:
  ```bash
  create_parking_lot 6
  ```
  Hasilnya akan seperti ini : 
  ```bash
  Created a parking lot with 6 slots
  ```
- `park <registration_number> <color> <type>`: Memarkir kendaraan dengan nomor registrasi, warna, dan jenis tertentu. 

   Contoh:
  ```bash
  park B-1234-XYZ Putih Mobil
  ```
  Hasilnya akan seperti ini : 
  ```bash
  Allocated slot number: 1
  ```
- `leave <slot_number>`: Mengosongkan slot parkir tertentu. 

   Contoh:
  ```bash
  leave 1
  ```
  Hasilnya akan seperti ini : 
  ```bash
  Slot number 1 is free
  ```
- `status`: Menampilkan status tempat parkir 

   Contoh:
  ```bash
  status
  ```
  Hasilnya akan seperti ini : (Semisal kita sudah memasukkan 4 data tambahan)
  ```bash
  Slot 	No. 		Type	Registration No Colour
  2 		B-9999-XYZ	Motor	Putih
  3 		D-0001-HIJ 	Mobil	Hitam
  4 		B-2701-XXX 	Mobil	Biru
  5 		B-3142-ZZZ 	Motor	Hitam
  ```
- `type_of_vehicles <type>`: Menghitung jumlah kendaraan berdasarkan jenis.

   Contoh:
  ```bash
  type_of_vehicles Motor
  ```
  Hasilnya akan seperti ini : 
  ```bash
  2
  ```
- `registration_numbers_for_vehicles_with_ood_plate`: Menampilkan nomor registrasi kendaraan dengan nomor plat ganjil.

   Contoh:
  ```bash
  registration_numbers_for_vehicles_with_ood_plate
  ```
  Hasilnya akan seperti ini : 
  ```bash
  B-9999-XYZ, D-0001-HIJ, B-2701-XXX
  ```
- `registration_numbers_for_vehicles_with_event_plate`: Menampilkan nomor registrasi kendaraan dengan nomor plat genap.

   Contoh:
  ```bash
  registration_numbers_for_vehicles_with_event_plate
  ```
  Hasilnya akan seperti ini : 
  ```bash
  B-3142-ZZZ
  ```
- `registration_numbers_for_vehicles_with_colour <color>`: Menampilkan nomor registrasi kendaraan berdasarkan warna.

   Contoh:
  ```bash
  registration_numbers_for_vehicles_with_colour Putih
  ```
  Hasilnya akan seperti ini : 
  ```bash
  B-9999-XYZ
  ```
- `slot_numbers_for_vehicles_with_colour <color>`: Menampilkan nomor slot berdasarkan warna kendaraan.

   Contoh:
  ```bash
  slot_numbers_for_vehicles_with_colour Putih
  ```
  Hasilnya akan seperti ini : 
  ```bash
  2
  ```
- `slot_number_for_registration_number <registration_number>`: Menampilkan nomor slot berdasarkan nomor registrasi kendaraan.

   Contoh:
  ```bash
  slot_number_for_registration_number B-3141-ZZZ
  ```
  Hasilnya akan seperti ini : 
  ```bash
  5
  ```
## Struktur Proyek
- Program.cs: Berisi logika utama aplikasi dan menangani input pengguna.
- ParkingLot.cs: Berisi logika untuk mengelola tempat parkir dan kendaraan.
- Vehicle.cs: Kelas model untuk merepresentasikan kendaraan.
## Contoh Penggunaan
  ```bash
$ create_parking_lot 6
Created a parking lot with 6 slots

$  park KA-01-HH-1234 White Car
Allocated slot number: 1

$  park KA-01-HH-9999 White Car
Allocated slot number: 2

$ leave 1
Slot number 1 is free

$ status
Slot   No.          Type    Registration No  Colour
2      KA-01-HH-9999  Car      White

$ type_of_vehicles Car
1

$ registration_numbers_for_vehicles_with_ood_plate
KA-01-HH-9999

$ registration_numbers_for_vehicles_with_event_plate

$ registration_numbers_for_vehicles_with_colour White
KA-01-HH-9999

$ slot_numbers_for_vehicles_with_colour White
2

$ slot_number_for_registration_number KA-01-HH-9999
2
  ```