﻿// <auto-generated />
using System;
using HelloWebApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace QuanLiCuaHang.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuanLiCuaHang.entity.ChiTietHoaDon", b =>
                {
                    b.Property<int>("ChiTietHoaDonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChiTietHoaDonId"));

                    b.Property<string>("DVT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HoaDonId")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasMaxLength(99)
                        .HasColumnType("int");

                    b.Property<double>("ThanhTien")
                        .HasColumnType("float");

                    b.HasKey("ChiTietHoaDonId");

                    b.HasIndex("HoaDonId");

                    b.HasIndex("SanPhamId");

                    b.ToTable("ChiTietHoaDons");
                });

            modelBuilder.Entity("QuanLiCuaHang.entity.HoaDon", b =>
                {
                    b.Property<int>("HoaDonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HoaDonId"));

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KhachHangId")
                        .HasColumnType("int");

                    b.Property<string>("MaGiaoDich")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHoaDon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ThoiGianCapNhap")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ThoiGianTao")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<double>("TongTien")
                        .HasColumnType("float");

                    b.HasKey("HoaDonId");

                    b.HasIndex("KhachHangId");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("QuanLiCuaHang.entity.KhachHang", b =>
                {
                    b.Property<int>("KhachHangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhachHangId"));

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KhachHangId");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("QuanLiCuaHang.entity.LoaiSanPham", b =>
                {
                    b.Property<int>("LoaiSanPhamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiSanPhamId"));

                    b.Property<string>("TenLoaiSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoaiSanPhamId");

                    b.ToTable("LoaiSanPhams");
                });

            modelBuilder.Entity("QuanLiCuaHang.entity.SanPham", b =>
                {
                    b.Property<int>("SanPhamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SanPhamId"));

                    b.Property<double>("GiaThanh")
                        .HasColumnType("float");

                    b.Property<string>("KyHieuSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiSanPhamId")
                        .HasColumnType("int");

                    b.Property<string>("Mota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayHetHan")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SanPhamId");

                    b.HasIndex("LoaiSanPhamId");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("QuanLiCuaHang.entity.ChiTietHoaDon", b =>
                {
                    b.HasOne("QuanLiCuaHang.entity.HoaDon", "HoaDon")
                        .WithMany("DanhSachChiTietHoaDons")
                        .HasForeignKey("HoaDonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLiCuaHang.entity.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoaDon");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("QuanLiCuaHang.entity.HoaDon", b =>
                {
                    b.HasOne("QuanLiCuaHang.entity.KhachHang", "KhachHang")
                        .WithMany("DanhSachHoaDon")
                        .HasForeignKey("KhachHangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");
                });

            modelBuilder.Entity("QuanLiCuaHang.entity.SanPham", b =>
                {
                    b.HasOne("QuanLiCuaHang.entity.LoaiSanPham", "LoaiSanPham")
                        .WithMany("DanhSachSanPhams")
                        .HasForeignKey("LoaiSanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiSanPham");
                });

            modelBuilder.Entity("QuanLiCuaHang.entity.HoaDon", b =>
                {
                    b.Navigation("DanhSachChiTietHoaDons");
                });

            modelBuilder.Entity("QuanLiCuaHang.entity.KhachHang", b =>
                {
                    b.Navigation("DanhSachHoaDon");
                });

            modelBuilder.Entity("QuanLiCuaHang.entity.LoaiSanPham", b =>
                {
                    b.Navigation("DanhSachSanPhams");
                });
#pragma warning restore 612, 618
        }
    }
}
