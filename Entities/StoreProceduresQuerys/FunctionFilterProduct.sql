USE [trabajo]
GO

/****** Object:  UserDefinedFunction [dbo].[ValidateFilterValue]    Script Date: 5/01/2024 9:32:25 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[ValidateFilterValue]
(
	@ProductId NVARCHAR(MAX),
    @Name NVARCHAR(MAX),
    @Description NVARCHAR(MAX),
    @Image NVARCHAR(MAX),
    @ChefId NVARCHAR(MAX),
    @Price NVARCHAR(MAX),
    @Serving NVARCHAR(MAX),
    @Ingredients NVARCHAR(MAX),
    @Active NVARCHAR(MAX),
    @CategoryId NVARCHAR(MAX),
    @Review NVARCHAR(MAX),
    @CatName NVARCHAR(MAX),
    @ChName NVARCHAR(MAX),
    @Phone NVARCHAR(MAX),
    @Cellphone NVARCHAR(MAX),
    @Email NVARCHAR(MAX),
    @ChImage NVARCHAR(MAX),
    @Cover NVARCHAR(MAX),
    @Gender NVARCHAR(MAX),
    @Nationality NVARCHAR(MAX),
    @Country NVARCHAR(MAX),
    @Department NVARCHAR(MAX),
    @Status NVARCHAR(MAX),
    @Certified NVARCHAR(MAX),
    @CertifiedMessage NVARCHAR(MAX),
    @ChDescription NVARCHAR(MAX),
    @ChActive NVARCHAR(MAX),
    @CatImage NVARCHAR(MAX),
    @CatActive NVARCHAR(MAX),
    @FilterValue NVARCHAR(MAX)	NULL
)
RETURNS BIT
AS
BEGIN
    DECLARE @Result BIT;

    SET @Result = 
		CASE
			WHEN @FilterValue IS NOT NULL
				THEN
				CASE 
					WHEN (
						@ProductId    LIKE '%' + @FilterValue + '%' OR
						@Name    LIKE '%' + @FilterValue + '%' OR
						@Description    LIKE '%' + @FilterValue + '%' OR
						@Image    LIKE '%' + @FilterValue + '%' OR
						@ChefId    LIKE '%' + @FilterValue + '%' OR
						@Price    LIKE '%' + @FilterValue + '%' OR
						@Serving    LIKE '%' + @FilterValue + '%' OR
						@Ingredients    LIKE '%' + @FilterValue + '%' OR
						@Active    LIKE '%' + @FilterValue + '%' OR
						@CategoryId    LIKE '%' + @FilterValue + '%' OR
						@Review    LIKE '%' + @FilterValue + '%' OR
						@CatName    LIKE '%' + @FilterValue + '%' OR
						@ChName    LIKE '%' + @FilterValue + '%' OR
						@Phone    LIKE '%' + @FilterValue + '%' OR
						@Cellphone    LIKE '%' + @FilterValue + '%' OR
						@Email    LIKE '%' + @FilterValue + '%' OR
						@Image    LIKE '%' + @FilterValue + '%' OR
						@Cover    LIKE '%' + @FilterValue + '%' OR
						@Gender    LIKE '%' + @FilterValue + '%' OR
						@Nationality    LIKE '%' + @FilterValue + '%' OR
						@Country    LIKE '%' + @FilterValue + '%' OR
						@Department    LIKE '%' + @FilterValue + '%' OR
						@Status    LIKE '%' + @FilterValue + '%' OR
						@Certified    LIKE '%' + @FilterValue + '%' OR
						@CertifiedMessage    LIKE '%' + @FilterValue + '%' OR
						@ChDescription    LIKE '%' + @FilterValue + '%' OR
						@ChActive    LIKE '%' + @FilterValue + '%' OR
						@CatImage    LIKE '%' + @FilterValue + '%' OR
						@CatActive    LIKE '%' + @FilterValue + '%'
					)
				THEN 1 
				ELSE 0 
			END
			ELSE 1
		END;

    RETURN @Result;
END;
GO


