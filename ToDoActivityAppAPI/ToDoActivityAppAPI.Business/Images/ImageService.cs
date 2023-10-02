﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.Images.DTOs;
using ToDoActivityAppAPI.DataAccess.Images;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.Business.Images
{
    public  class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task AddImage(AddImageDTO addImageDTO)
        {
            foreach (var imageFile in addImageDTO.Images)
            {
                if (imageFile.Length == 0)
                {
                    continue;
                }
                   

                using (var stream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(stream);

                    var image = new Image
                    {
                        FileName = imageFile.FileName,
                        ContentType = imageFile.ContentType,
                        ImageData = stream.ToArray(),
                        ActivityId = addImageDTO.ActivityId,
                    };

                    await _imageRepository.AddImage(image);
                }
            }
            
        }

        public async Task DeleteAllActivityImages(int activityId)
        {
            await _imageRepository.DeleteAllActivityImages(activityId);
        }

        public async Task DeleteImage(int imageId)
        {
            await _imageRepository.DeleteImage(imageId);
        }

        public async Task<List<GetImageDTO>> GetActivityImagesById(int activityId)
        {
            var images = await _imageRepository.GetActivityImagesById(activityId);

            var imagesMetadata = _mapper.Map<List<GetImageDTO>>(images);

            return imagesMetadata;
        }
    }
}
